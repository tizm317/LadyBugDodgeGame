using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player_Fire : MonoBehaviour
{
    public GameObject PlayerMissile;    // 복제할 미사일 오브젝트 // Projectile 인거고
    public Transform MissileLocation;   // 미사일이 발사될 위치 // muzzle
    public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 미사일 발사 속도를 제어할 변수

    public int MissileMaxPool;          // 메모리 풀에 저장할 미사일 개수
    private MemoryPool MPool;           // 메모리 풀
    private GameObject[] MissileArray;  // 메모리 풀과 연동하여 사용할 미사일 배열

    float shootTimer = 0f;
    //float shootDelay = 1f;

    //쿨타임 시스템 0 123 456 789 101112 131415
    public float CoolTime = 15.0f;
    const float Min = 3.0f;
    const float Max = 15.0f;
    public float Cool = 1.2f;

    JoyStick_R joystick_r;

    private float MoveSpeed = 10; // 미사일이 날라가는 속도 / PlyaerMissile_Move 에도 있음 맞춰야함

    public GameObject bullet_parent; // 총알 메모리풀을 캐릭터 내 child 로 만들기 위해 부모 오브젝트 선언 , player_fire 달고 있는 자기 자신이 부모가 됨

    public GameObject[] FireMissileArray; //

    double code = 0.0; // 속성별 코드
    //bool FireLv2 = false;
    //bool FireLv3 = false;
    public Sprite FireBullet;

    int BulletCount = 0;

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
        // PlayerMissile을 MissileMaxPool만큼 생성합니다.
        MPool.Create(PlayerMissile, MissileMaxPool, bullet_parent); // MPool.Create(Projectile, MissileMaxPool) // 수정 : 부모 오브젝트 아래에 생기도록 바꿈
        // 배열도 초기화 합니다.(이때 모든 값은 null이 됩니다.)
        MissileArray = new GameObject[MissileMaxPool];

        FireMissileArray = new GameObject[5];

        joystick_r = GameObject.Find("JoyStick_R").GetComponent<JoyStick_R>();

    }

    void Update()
    {
        if (transform.GetComponent<Element>())
            code = transform.GetComponent<Element>().player_element;


        // 매 프레임마다 미사일발사 함수를 체크한다.
        //playerFire();
        MissileCheck();

        // 쿨타임
        if (CoolTime < Max)
            CoolTime += Time.deltaTime * Cool;

        
        
            if (code == 1.1 || code == 2.1 || code == 3.1 || code == 4.1 || code == 5.1)
            {
                if (FireMissileArray[0] != null)
                {
                        if (FireMissileArray[0].activeSelf == false && FireMissileArray[1].activeSelf == false && FireMissileArray[2].activeSelf == false)
                        {
                                // 모든 총알이 비활성화 되어야 IsShooting = false
                                 // 안그러면 총알 하나만 비활성화 되도 총알 발사중이 아닌게 되버림
                                 // 속성 2레벨
                                joystick_r.IsShooting = false;
                        }

                        if (joystick_r.IsShooting == true)
                        {
                            // 버그 때문에 if 추가해봄
                            Vector2 v2One = Vector2.zero;          // 1번
                            Vector2 v2Two = joystick_r.PointerUpVect.normalized;          // 2번
                            Vector2 v2Three = Vector2.zero;        // 3번
                            Vector2 v2Four = Vector2.zero;        // 3번

                            Quaternion qAngle = Quaternion.identity;    // 회전시킬 각도

                            Vector2 v2Temp = v2Two - v2One;        // 1번에 대한 2번의 상대 위치값
                            qAngle = Quaternion.Euler(0f, 0f, 45f);    // Y축으로 20도 회전할 angle값.
                            v2Three = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                            v2Three = v2Three + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                            qAngle = Quaternion.Euler(0f, 0f, -45f);    // Y축으로 20도 회전할 angle값.
                            v2Four = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                            v2Four = v2Four + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                            FireMissileArray[0].gameObject.transform.Translate(v2Three.normalized * MoveSpeed * Time.deltaTime);
                            FireMissileArray[1].gameObject.transform.Translate(v2Two.normalized * MoveSpeed * Time.deltaTime);
                            FireMissileArray[2].gameObject.transform.Translate(v2Four.normalized * MoveSpeed * Time.deltaTime);
                            //FireMissileArray[1].gameObject.transform.Translate(joystick_r.PointerUpVect.normalized   * MoveSpeed * Time.deltaTime);
                        }
                }
            }
            else if (code == 1.2 || code == 2.2 || code == 3.2 || code == 4.2 || code == 5.2)
            {
                if (FireMissileArray[4] != null)
                {
                         if (FireMissileArray[0].activeSelf == false && FireMissileArray[1].activeSelf == false && FireMissileArray[2].activeSelf == false && FireMissileArray[3].activeSelf == false && FireMissileArray[4].activeSelf == false)
                         {
                            // 모든 총알이 비활성화 되어야 IsShooting = false
                            // 안그러면 총알 하나만 비활성화 되도 총알 발사중이 아닌게 되버림
                            // 속성 3레벨
                            joystick_r.IsShooting = false;
                         }

                         if(joystick_r.IsShooting == true)
                         {
                            // 원인 모를 버그 때문에 해봄
                            Vector2 v2One = Vector2.zero;          // 1번
                            Vector2 v2Two = joystick_r.PointerUpVect.normalized;          // 2번
                            Vector2 v2Three = Vector2.zero;        // 3번
                            Vector2 v2Four = Vector2.zero;        // 4번
                            Vector2 v2Five = Vector2.zero;        // 4번
                            Vector2 v2Six = Vector2.zero;        // 4번



                            Quaternion qAngle = Quaternion.identity;    // 회전시킬 각도

                            Vector2 v2Temp = v2Two - v2One;        // 1번에 대한 2번의 상대 위치값
                            qAngle = Quaternion.Euler(0f, 0f, 45f);    // Y축으로 20도 회전할 angle값.
                            v2Three = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                            v2Three = v2Three + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)
                            qAngle = Quaternion.Euler(0f, 0f, -45f);    // Y축으로 20도 회전할 angle값.
                            v2Four = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                            v2Four = v2Four + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                            qAngle = Quaternion.Euler(0f, 0f, 22.5f);    // Y축으로 20도 회전할 angle값.
                            v2Five = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                            v2Five = v2Five + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                            qAngle = Quaternion.Euler(0f, 0f, -22.5f);    // Y축으로 20도 회전할 angle값.
                            v2Six = qAngle * v2Temp;      // 2번-1번 값의 벡터를 Y축으로 20도 회전한 값.
                            v2Six = v2Six + v2One;                  // v3One을 더해줘서 월드상 위치에 맞는 좌표로 이동.(더해주기 전에는 V3One에 대한 상대(로컬)좌표)

                            FireMissileArray[0].gameObject.transform.Translate(v2Three.normalized * MoveSpeed * Time.deltaTime);
                            FireMissileArray[1].gameObject.transform.Translate(v2Two.normalized * MoveSpeed * Time.deltaTime);
                            //FireMissileArray[1].gameObject.transform.Translate(joystick_r.PointerUpVect.normalized * MoveSpeed * Time.deltaTime);
                            FireMissileArray[2].gameObject.transform.Translate(v2Four.normalized * MoveSpeed * Time.deltaTime);
                            FireMissileArray[3].gameObject.transform.Translate(v2Five.normalized * MoveSpeed * Time.deltaTime);
                            FireMissileArray[4].gameObject.transform.Translate(v2Six.normalized * MoveSpeed * Time.deltaTime);
                        }
                        

               
                }
            }
    }
        
        
    

    // 미사일을 발사하는 함수
    public void playerFire()
    {
        // 제어변수가 true일때만 발동
        if (FireState)
        {
            // 키보드의 "A"를 누르면
            //if(JoyStick_R.)
            //if(Input.GetKey(KeyCode.A))
            //if (shootTimer > shootDelay)
            //if(true)
            if (CoolTime >= Min)
            {
                //쿨타임
                CoolTime -= Min;

                //총알 발사되고 있는 중
                joystick_r.IsShooting = true;

                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());

                /*
                if (code == 1.1 || code == 1.2)
                {
                    FireMissile();
                }
                else if (code == 2.1 || code == 2.2)
                    WaterMissile();
                */
                if (code == 0 || code == 1 || code == 2 || code == 3 || code == 4 || code == 5)
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

                            // 발사 후에 for문을 바로 빠져나간다.
                            break;
                        }
                    }
                }
                else
                {
                    FireMissile();
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
        int count = 0;
        if (code == 1.1 || code == 2.1 || code == 3.1 || code == 4.1 || code == 5.1)
        {
            BulletCount = 3;
        }
        else if (code == 1.2 || code == 2.2 || code == 3.2 || code == 4.2 || code == 5.2)
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
