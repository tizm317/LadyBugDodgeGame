using UnityEngine;
public class EnemyMissile_Move : MonoBehaviour
{
    public float MoveSpeed; // 미사일이 날라가는 속도
    //public float DestroyYPos; // 미사일이 사라지는 지점 y축
    //public float DestroyXPos; // 미사일이 사라지는 지점 x축

    float lifeTime = 5f; // 미사일 lifetime , 밑에 초기화 할 때 처음 설정값과 똑같이 해야함
    float fire_lifeTIme = 1.5f;

    public Transform ZeroPoint;

    Vector2 dir;

    double code = 0.0; // 속성별 코드

    public float distance;

    //public GameObject MissileDestroyingEffect;

    // 금 속성 체력
    // 2번 맞으면 부서짐
    public int BulletHP = 1; // 최대 3방

    GameObject EffectList;

    // 타워 레벨에 따라 가중치
    int TowerLevel;

    private void OnEnable()
    {
        if(this.GetComponentInParent<TowerStatusYellow>())
            TowerLevel = this.GetComponentInParent<TowerStatusYellow>().TowerLevel;

        // 총알 체력 초기화
        if (TowerLevel <= 4)
            BulletHP = 1;
        else
            BulletHP = 2;

        //else if (TowerLevel <= 4)
        //    BulletHP = 2;
        //else
        //    BulletHP = 3;
    }


    private void Start()
    {
        ZeroPoint = GameObject.Find("Player").transform; // 원점

        dir = (ZeroPoint.position - transform.position) / Mathf.Sqrt((transform.position.x)*(transform.position.x) + (transform.position.y)*(transform.position.y));
        //Debug.Log(dir);


        EffectList = GameObject.Find("EffectManager").gameObject;
    }

    void Update()
    {
        code = this.GetComponentInParent<AttackSystem>().code;
        MoveSpeed = this.GetComponentInParent<AttackSystem>().MoveSpeed;

        //Vector2.up
        // 매 프레임마다 미사일이 MoveSpeed 만큼 원점 방향으로 날라갑니다.
        if(code == 2 || code == 3 || code == 5)
            transform.Translate(dir * MoveSpeed * Time.deltaTime);
        else if(code == 4)
        {
            // 유도 미사일
            GameObject magnetic = GameObject.Find("Character");

            distance = Vector2.Distance(magnetic.transform.position, transform.position);

            // 방향
            Vector3 directionToMagnet = magnetic.transform.position - transform.position;

            // 거리별 속도
            if (distance <= 1.0f)
            {
                transform.position = magnetic.transform.position;
            }
            else if (distance <= 4.0f)
                MoveSpeed = 2.0f;
            else
                MoveSpeed = distance * 0.5f;

            transform.Translate(directionToMagnet.normalized * MoveSpeed * Time.deltaTime);
        }
        lifeTime -= Time.deltaTime;

        if(code == 1)
            fire_lifeTIme -= Time.deltaTime;


        /* 미사일이 사라지는 경우
           1. 설정된 x,y 축 값을 벗어나는 경우 (맵을 벗어나는 경우) 
           2. 설정된 lifeTime 끝날경우
           3. 장애물/적 과 충돌 할 경우 : 데미지를 입힘

            // 마지막에 lifeTime 초기화 시켜야 함 , 초기화 할 때 초기값과 동일하게 설정해야함
        */




        // 범위
        if (19 * Mathf.Abs(transform.position.y) + 12 * Mathf.Abs( transform.position.x) - 12 * 19 > 0)
        {
            GetComponent<Collider2D>().enabled = false;
        }

        //// 2. lifetime 끝나면
        // 유도 미사일에만 적용
        if(code == 4)
        {
            if (lifeTime <= 0)
            {
                // 미사일을 다시 메모리 풀에
                EffectList.transform.GetChild(45).gameObject.SetActive(true);
                EffectList.transform.GetChild(45).gameObject.transform.position = transform.position;
                Invoke("Disabled", 1);
                //Instantiate(MissileDestroyingEffect, transform.position, transform.rotation);  // 미사일 터지는 이펙트 실행
                GetComponent<Collider2D>().enabled = false;
            }
        }
        else if(code == 1)
        {
            if (fire_lifeTIme <= 0)
            {
                // 미사일을 다시 메모리 풀에
                //EffectList.transform.GetChild(45).gameObject.SetActive(true);
                //EffectList.transform.GetChild(45).gameObject.transform.position = transform.position;
                //Invoke("Disabled", 1);
                //Instantiate(MissileDestroyingEffect, transform.position, transform.rotation);  // 미사일 터지는 이펙트 실행
                GetComponent<Collider2D>().enabled = false;
            }
        }



        // lifeTime 초기화
        if (GetComponent<Collider2D>().enabled == false)
        {
            lifeTime = 5f;
            fire_lifeTIme = 1.5f;
        }
    }

    //  3. 장애물/적 과 충돌 할 경우 + 데미지를 입힘(Hp : 현재 experience 에서 관리)
    // OnColliderEnter2D(Collider2D ) 이거 썼었는데 Hp 가 두배로 줄어서 뭐가 문제지 하고 찾아보니 이거는 통과할 때 사용하는 거고 + IsTrigger 둘다 켜져있어야함
    // Collision 을 쓰면 충돌 하는 경우임 + IsTrigger 둘다 꺼져 있어야 하고
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Collider2D>().enabled = false;
            lifeTime = 5f;
            fire_lifeTIme = 1.5f;
            
            if (code == 5)
            {
                // 토 속성 
                // 슬로우 : 총알 충돌 시 플레이어 1초 간 슬로우
                // Joy_stick 스크립트와 관련
                GameObject.Find("Canvas").GetComponent<Joy_stick>().IsSlow = true;
                //Joy_stick 스크립트에서 1초후 해제
                //Invoke("ChangeToOriSpeed", 1f); // Invoke 때문에 오류 생기는거 같아서 바꿈
            }
        }
        else if(collision.gameObject.tag == "Food")
        {
            if(code == 3)
                collision.gameObject.SetActive(false); //비활성화
        }
        else if(collision.gameObject.tag == "Element")
        {
            if (code == 3)
                collision.gameObject.SetActive(false); //비활성화
        }
        else if(collision.gameObject.tag == "Attacking_Bullet")
        {
            if (code == 4)
            {
                //collision.gameObject.SetActive(false); // 비활성화
                collision.gameObject.GetComponent<Collider2D>().enabled = false;


                BulletHP--;
                if(BulletHP <= 0)
                {
                    EffectList.transform.GetChild(45).gameObject.SetActive(true);
                    EffectList.transform.GetChild(45).gameObject.transform.position = transform.position;
                    Invoke("Disabled", 1);
                    //Instantiate(MissileDestroyingEffect, transform.position, transform.rotation);  // 미사일 터지는 이펙트 실행
                    this.gameObject.GetComponent<Collider2D>().enabled = false;
                    //this.gameObject.SetActive(false); // 비활성화
                }

            }
        }
    }

    void Disabled()
    {
        EffectList.transform.GetChild(45).gameObject.SetActive(false);
    }
}