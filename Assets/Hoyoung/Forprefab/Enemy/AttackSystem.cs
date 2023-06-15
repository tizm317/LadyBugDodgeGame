using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    /* 총알 시스템
     * 1. 물속성 : 직선으로 총알을 발사한다. 패턴은 쉽지만 데미지가 강함
     *      - code = 2
     *      - 1 발씩
     *      - MoveSpeed 10
     *      - damage :
     * 2. 불속성 : 방사하는 총알을 발사한다. 대신 총알 속도가 조금 느리다
     *      - code = 1
     *      - 5 발씩
     *      - MoveSpeed 8
     *      - damage :
     *      - 각도  : 25 / 12.5도
     * 3. 전기속성 : 유도 미사일을 발사한다. 유도미사일은 파괴 가능하다
     *      - code = 4
     *      - 1 발씩
     *      - MoveSpeed
     *      속도 : distance <= 1 : 충돌
     *              -1 < distance <= 4 : 4f 로 유지 // 속도 조절 할 때 이거 수정하면 될 듯
     *              5 < distance : MoveSpeed = distance
     *      - damage :
     */

    public GameObject PlayerMissile;    // 복제할 미사일 오브젝트 // Projectile 인거고
    public Transform MissileLocation;   // 미사일이 발사될 위치 // muzzle
    public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 미사일 발사 속도를 제어할 변수

    public int MissileMaxPool;          // 메모리 풀에 저장할 미사일 개수
    private MemoryPool MPool;           // 메모리 풀
    private GameObject[] MissileArray;  // 메모리 풀과 연동하여 사용할 미사일 배열

    float shootTimer = 0f;
    public float shootDelay = 2f;



    public float MoveSpeed = 10; // 미사일이 날라가는 속도 / PlyaerMissile_Move 에도 있음 맞춰야함

    public GameObject bullet_parent; // 총알 메모리풀을 캐릭터 내 child 로 만들기 위해 부모 오브젝트 선언 , player_fire 달고 있는 자기 자신이 부모가 됨

    public GameObject[] FireMissileArray; //
    public GameObject[] YellowMissileArray; //


    public double code = 0.0; // 속성별 코드
    //bool FireLv2 = false;
    //bool FireLv3 = false;
    public Sprite FireBullet;

    int BulletCount = 0;


    // 총알 여러개 발사할 때 생기는 문제 해결 위해
    // 화 속성 방사
    bool EveryBulletOff = true;


    // 수 속성 점사
    public bool LastBullet = false;     // 5발 중 마지막 총알 발사 여부
    public float WaterInterval = 3f;    // 점사(5발) 와 점사(5발) 사이 간격


    // 게임이 종료되면 자동으로 호출되는 함수
    private void OnApplicationQuit()
    {
        // 메모리 풀을 비웁니다.
        MPool.Dispose();
    }

    void Start()
    {
        // 처음에 미사일을 발사할 수 있도록 제어변수를 true로 설정
        FireState = true;

        // 메모리 풀을 초기화합니다.
        MPool = new MemoryPool();

        bullet_parent = this.gameObject;
        MissileLocation = this.gameObject.transform;

        // PlayerMissile을 MissileMaxPool만큼 생성합니다.
        MPool.Create(PlayerMissile, MissileMaxPool, bullet_parent); // MPool.Create(Projectile, MissileMaxPool) // 수정 : 부모 오브젝트 아래에 생기도록 바꿈
        // 배열도 초기화 합니다.(이때 모든 값은 null이 됩니다.)
        MissileArray = new GameObject[MissileMaxPool];

        FireMissileArray = new GameObject[5];
        YellowMissileArray = new GameObject[5];
    }

    void Update()
    {
        // 총알 여러개 발사 해결위해
            if (transform.GetChild(1).gameObject.activeSelf == false && transform.GetChild(2).gameObject.activeSelf == false && transform.GetChild(3).gameObject.activeSelf == false && transform.GetChild(4).gameObject.activeSelf == false && transform.GetChild(5).gameObject.activeSelf == false)
                EveryBulletOff = true;
            else
                EveryBulletOff = false;
        

        //if (transform.GetComponent<Element>())
        //    code = transform.GetComponent<Element>().player_element;

        if (this.gameObject.GetComponent<TowerStatusRed>())
            code = this.gameObject.GetComponent<TowerStatusRed>().code;
        else if (this.gameObject.GetComponent<TowerStatusBlue>())
            code = this.gameObject.GetComponent<TowerStatusBlue>().code;
        else if (this.gameObject.GetComponent<TowerStatusGreen>())
            code = this.gameObject.GetComponent<TowerStatusGreen>().code;
        else if (this.gameObject.GetComponent<TowerStatusYellow>())
            code = this.gameObject.GetComponent<TowerStatusYellow>().code;
        else if (this.gameObject.GetComponent<TowerStatusPurple>())
            code = this.gameObject.GetComponent<TowerStatusPurple>().code;

        // 매 프레임마다 미사일발사 함수를 체크한다.
        if(code != 2) // 수속성 외 나머지 ( 토, 목 속성)
            playerFire();
        else
        {
            // 수속성
            // 점사
            if (LastBullet == false)
                playerFire(); 
            else                                    // 5발 중 마지막 총알이 발사되면 다음 발사 까지 쿨타임
                WaterInterval -= Time.deltaTime;

            if(WaterInterval <= 0.0)                // 쿨타임 다 돌면
            {                                       //  LastBullet 초기화
                LastBullet = false;
                WaterInterval = 3f;                 // 쿨타임 초기화
            }
        }
        MissileCheck();

        

        // 불속성
        if (this.gameObject.GetComponent<TowerStatusRed>())
        {
            if (FireMissileArray[4] != null)
            {
                Vector2 v2One = Vector2.zero;          // 1번
                Vector2 v2Two = (new Vector3(0 - transform.position.x, 0-transform.position.y, 0)).normalized;          // 2번
                Vector2 v2Three = Vector2.zero;        // 3번
                Vector2 v2Four = Vector2.zero;        // 4번
                Vector2 v2Five = Vector2.zero;        // 4번
                Vector2 v2Six = Vector2.zero;        // 4번



                Quaternion qAngle = Quaternion.identity;    // 회전시킬 각도

                Vector2 v2Temp = v2Two - v2One;        // 1번에 대한 2번의 상대 위치값
                qAngle = Quaternion.Euler(0f, 0f, 25f);    // Y축으로 25도 회전할 angle값.
                v2Three = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                v2Three = v2Three + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)
                qAngle = Quaternion.Euler(0f, 0f, -25f);    // Y축으로 25도 회전할 angle값.
                v2Four = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                v2Four = v2Four + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                qAngle = Quaternion.Euler(0f, 0f, 12.5f);    // Y축으로 12,5도 회전할 angle값.
                v2Five = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                v2Five = v2Five + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                qAngle = Quaternion.Euler(0f, 0f, -12.5f);    // Y축으로 12.5도 회전할 angle값.
                v2Six = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                v2Six = v2Six + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                FireMissileArray[0].gameObject.transform.Translate(v2Three.normalized * MoveSpeed * Time.deltaTime);
                FireMissileArray[1].gameObject.transform.Translate((new Vector3(0 - transform.position.x, 0 - transform.position.y, 0)).normalized * MoveSpeed * Time.deltaTime);
                FireMissileArray[2].gameObject.transform.Translate(v2Four.normalized * MoveSpeed * Time.deltaTime);
                FireMissileArray[3].gameObject.transform.Translate(v2Five.normalized * MoveSpeed * Time.deltaTime);
                FireMissileArray[4].gameObject.transform.Translate(v2Six.normalized * MoveSpeed * Time.deltaTime);


            }
        }
        
    }




    // 미사일을 발사하는 함수
    public void playerFire()
    {
        // 제어변수가 true일때만 발동
        if (FireState)
        {
            //if(CoolTime >= Min)


            if (shootTimer > shootDelay)
            {
                ////쿨타임
                //CoolTime -= Min;


                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());

               
                if ( code == 2 || code == 3 || code == 5)
                {
                    // 수,목,토 속성 : 일자 형태 총알
                    // 속도 : 10 -> 8
                    MoveSpeed = 8;

                    // 토 속성 속도
                    if(code == 5)
                        MoveSpeed = 4;

                    // 수 속성 : 딜레이 0.1f ( 점사 )
                    // MissileMaxPool - 2 한 이유 : 가까이에서 공격 계속 맞으면 무한적으로 생겨서 총알 수 줄임
                    if (code == 2)
                    {
                        shootDelay = 0.1f;

                        for (int i = 0; i < MissileMaxPool - 2; i++)
                        {
                            // 만약 미사일배열[i]가 비어있다면
                            if (MissileArray[i] == null)
                            {
                                // 메모리풀에서 미사일을 가져온다.
                                MissileArray[i] = MPool.NewItem();
                                // 해당 미사일의 위치를 미사일 발사지점으로 맞춘다.
                                MissileArray[i].transform.position = MissileLocation.transform.position;
                                //MissileArray[i].transform.rotation = MissileLocation.transform.rotation;

                                // 수 속성 점사
                                if (i == MissileMaxPool -3)
                                    LastBullet = true;
                                else
                                    LastBullet = false;
                                // 발사 후에 for문을 바로 빠져나간다.
                                break;
                            }
                        }
                    }
                    else // 토 속성 목 속성
                    {
                        // 미사일 풀에서 발사되지 않은 미사일을 찾아서 발사합니다.
                    for (int i = 0; i < MissileMaxPool; i++)
                    {
                        // 만약 미사일배열[i]가 비어있다면
                        if (MissileArray[i] == null)
                        {
                            // 메모리풀에서 미사일을 가져온다.
                            MissileArray[i] = MPool.NewItem();
                            // 해당 미사일의 위치를 미사일 발사지점으로 맞춘다.
                            MissileArray[i].transform.position = MissileLocation.transform.position;
                            //MissileArray[i].transform.rotation = MissileLocation.transform.rotation;

                            // 수 속성 점사
                            if (i == MissileMaxPool - 1)
                                LastBullet = true;
                            else
                                LastBullet = false;
                            // 발사 후에 for문을 바로 빠져나간다.
                            break;
                        }
                    }
                    }
                    
                }
                else if(code == 1)
                {
                    // 불속성 : 방사 형태 총알
                    // 5개 총알 모두 비활성화 될 때만 다음 총알 발사함
                    if(EveryBulletOff == true)
                        FireMissile();
                }
                else if(code == 4)
                {
                    // 전기속성 : 유도 총알
                    // 속도 : 총알 스크립트에 써있음 / 거리별 속도
                    shootDelay = 5f;
                    //MoveSpeed = 4;

                    // 미사일 풀에서 발사되지 않은 미사일을 찾아서 발사합니다.
                    for (int i = 0; i < MissileMaxPool; i++)
                    {
                        // 만약 미사일배열[i]가 비어있다면
                        if (MissileArray[i] == null)
                        {
                            // 메모리풀에서 미사일을 가져온다.
                            MissileArray[i] = MPool.NewItem();
                            // 해당 미사일의 위치를 미사일 발사지점으로 맞춘다.
                            MissileArray[i].transform.position = MissileLocation.transform.position;

                            // 발사 후에 for문을 바로 빠져나간다.
                            break;
                        }
                    }
                }


                shootTimer = 0f;

            }
            shootTimer += Time.deltaTime; //쿨타임을 카운트 합니다.

        }

        // 미사일이 발사될때마다 미사일을 메모리풀로 돌려보내는 것을 체크한다.
        for (int i = 0; i < MissileMaxPool; i++)
        {
            // 만약 미사일[i]가 활성화 되어있다면
            if (MissileArray[i])
            {
                // 미사일[i]의 Collider2D가 비활성 되었다면
                if (MissileArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    // 다시 Collider2D를 활성화 시키고
                    MissileArray[i].GetComponent<Collider2D>().enabled = true;
                    // 미사일을 메모리로 돌려보내고
                    MPool.RemoveItem(MissileArray[i]);
                    // 가리키는 배열의 해당 항목도 null(값 없음)로 만든다.
                    MissileArray[i] = null;
                }
            }
        }
    }

    void MissileCheck()
    {
        for (int i = 0; i < MissileMaxPool; i++)
        {
            // 만약 미사일[i]가 활성화 되어있다면
            if (MissileArray[i])
            {
                // 미사일[i]의 Collider2D가 비활성 되었다면
                if (MissileArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    // 다시 Collider2D를 활성화 시키고
                    MissileArray[i].GetComponent<Collider2D>().enabled = true;
                    // 미사일을 메모리로 돌려보내고
                    MPool.RemoveItem(MissileArray[i]);
                    // 가리키는 배열의 해당 항목도 null(값 없음)로 만든다.
                    MissileArray[i] = null;
                }
            }
        }
    }

    // 코루틴 함수
    IEnumerator FireCycleControl()
    {
        // 처음에 FireState를 false로 만들고
        FireState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(FireDelay);
        // FireState를 true로 만든다.
        FireState = true;
    }

    

    void FireMissile()
    {
        // 불 속성 총알 발사 : 현재는 5발만
        // 속도 : 10 -> 8 -> 6
        MoveSpeed = 6;

        int count = 0;
        if (code == 1.1)
        {
            BulletCount = 3;
        }
        else if (code == 1)
        {
            BulletCount = 5;
        }
        // 미사일 풀에서 발사되지 않은 미사일을 찾아서 발사합니다.
        for (int i = 0; i < MissileMaxPool; i++)
        {
            // 만약 미사일배열[i]가 비어있다면
            if (MissileArray[i] == null)
            {
                // 메모리풀에서 미사일을 가져온다.
                MissileArray[i] = MPool.NewItem();
                // 해당 미사일의 위치를 미사일 발사지점으로 맞춘다.
                MissileArray[i].transform.position = MissileLocation.transform.position;
                //MissileArray[i].transform.rotation = MissileLocation.transform.rotation;

                FireMissileArray[count] = MissileArray[i];
                //FireMissileArray[count].GetComponent<SpriteRenderer>().sprite = FireBullet;


                //FireMissileArray[count].gameObject.tag = "FireBullet";
                count++;

            }

            if (count == BulletCount)
                break;
        }
    }


}
