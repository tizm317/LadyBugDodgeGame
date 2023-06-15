 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    /* Effect */
    static public GameObject EffectList;
    int n; // skill level up effect : 25
    bool changingEffect = false;

    /* element code */
    //static public int element_code; // 속성 구슬의 코드를 받아와야함 ..

    public double player_element = 0; // 주속성
    public double player_element_code_1 = 0; // 플레이어의 코드 1  
    public double player_element_code_2 = 0; // 플레이어의 코드 2  

    /* effect */
    public GameObject ChangeEffect;
    public GameObject RemoveEffect;

    int i;

    public bool IsFull = false;
    public bool Eat_SameElement = false;


    int eaten_element_code; // 충돌한 속성 구슬 의 속성값

    public int NoticeNum = 0;

    /* 총알 발사 도중 바꾸는 버튼, 버리는 버튼 방지*/
    JoyStick_R joystick_r;


    /* Change Effect*/
    void Changing_Effect(int code)
    {
        changingEffect = true;

        switch (code) // ( 더블 형식의 주속성을 정수 형태로 변환해서 받음 : 이유는 n.m 의 색은 n 색과 같기 때문)
        {
            case 1:
                n = 37;
                break;
            case 2:
                n = 38;

                break;

            case 3:
                n = 39;
                break;

            case 4:
                n = 40;
                break;

            case 5:
                n = 41;
                break;

        }
        //Instantiate(element, transform.position, transform.rotation);
        //Destroy(element, lifetime);

        EffectList.transform.GetChild(n).gameObject.SetActive(true);
        EffectList.transform.GetChild(n).gameObject.transform.position = transform.position;
        Invoke("Disabled", 1);

    }
    void Disabled()
    {
        EffectList.transform.GetChild(n).gameObject.SetActive(false);

        if (changingEffect)
            changingEffect = false;
    }

    /* Remove Effect */
    void Remove_Effect(int code)
    {
        switch (code) // ( 더블 형식의 주속성을 정수 형태로 변환해서 받음 : 이유는 n.m 의 색은 n 색과 같기 때문)
        {
            case 1:
                n = 32;
                break;
            case 2:
                n = 33;

                break;

            case 3:
                n = 34;
                break;

            case 4:
                n = 35;
                break;

            case 5:
                n = 36;
                break;

        }
        //Instantiate(element, transform.position, transform.rotation);
        //Destroy(element, lifetime);

        EffectList.transform.GetChild(n).gameObject.SetActive(true);
        EffectList.transform.GetChild(n).gameObject.transform.position = transform.position;
        Invoke("Disabled", 1);

    }

    /*
    void Disabled()
    {
        NewBulletEffectFX.EffectList.transform.GetChild(i).gameObject.SetActive(false);
    }
    */

    public void Remove_Element() // 주속성 버리기 , 버튼 누르면 실행 되도록
    {
        if (Pause.IsPause == false)
        {
            if (player_element_code_1 != 0 && player_element_code_2 != 0) // 속성이 두개일 때
            {
                if (joystick_r.IsShooting == false)
                {
                    //총알 발사중일 때 안됨
                    if (player_element == player_element_code_1) // 주속성이 code 1 일 때
                    {
                        Remove_Effect((int)player_element);
                        player_element = player_element_code_2; // 주속성이 code2로 바뀌고 code1 사라짐
                        player_element_code_1 = 0;

                    }
                    else // 주속성이 code 2 일 때
                    {
                        Remove_Effect((int)player_element);
                        player_element = player_element_code_1; // 주속성이 code1으로 바뀌고 code2 사라짐
                        player_element_code_2 = 0;

                    }
                    IsFull = false;
                    ChangeColor(player_element);
                }

                //이펙트
                //i = 17;
                //NewBulletEffectFX.EffectList.transform.GetChild(17).gameObject.transform.position = transform.position;
                //NewBulletEffectFX.EffectList.transform.GetChild(17).gameObject.SetActive(true);
                //Invoke("Disabled", 1);
            }
            else
            {
                NoticeNum = 1;
                //NoticeUI.text = "속성이 하나 이하면 버릴 수 없습니다!";
                //Invoke("RemoveNotice", 3f);
                //Debug.Log("속성이 하나 이하면 버릴 수 없습니다!");
            }
        }
    }

    public void Change_Element() // 주속성 바꾸기 , 버튼 누르면 실행 되도록
    {
        if (Pause.IsPause == false)
        {
            if (player_element_code_1 != 0 && player_element_code_2 != 0) // 속성이 2개여야 실행
            {
                if (joystick_r.IsShooting == false)
                {
                    // 총알 발사중이 아닐때만 가능
                    if (player_element == player_element_code_1) // 주속성이 code 1 이면 code2 로 바뀜
                    {
                        player_element = player_element_code_2;
                        Changing_Effect((int)player_element);
                    }
                    else
                    {
                        player_element = player_element_code_1; // 반대
                        Changing_Effect((int)player_element);
                    }
                    ChangeColor(player_element); // 색깔 변경
                }

                //이펙트
                //i = 18;
                //NewBulletEffectFX.EffectList.transform.GetChild(18).gameObject.transform.position = transform.position;
                //NewBulletEffectFX.EffectList.transform.GetChild(18).gameObject.SetActive(true);
                //Invoke("Disabled", 1);
            }
            else
            {
                NoticeNum = 8;
                //NoticeUI.text = "속성이 두개여야 바꿀 수 있습니다!";
                //Invoke("RemoveNotice", 3f);
                //Debug.Log("속성이 두개여야 바꿀 수 있습니다!");

            }
        }
            
    }

    /* 구슬 먹을 때 속성 바뀌는 코드
     * 경우의 수
     * 코드1 | 코드2
     * x        x   : 코드 1이 바뀌고 주속성 코드1
     * x        o   : 코드 1이 바뀌지만 주속성 코드2 그대로
     * 공통 코드 : 코드1 = 먹은 코드
     * o        x   : 코드 2가 바뀌지만 주속성 코드1 그대로
     * o        o   : 안바뀜
     */

    void Eat_Element(int eaten_code) // 입력 : 먹은 구슬 코드
    {
        if (player_element_code_1 == 0) // 코드1 빔( 코드 2가 차있을 수도 없을 수도 있음)
        {
           
            
            //ChangeColor(player_element_code_1); // 문제 : 코드2가 있는 경우 주속성이 안바뀌었는데 색 변경되는 문제
             

            if (player_element_code_2 == 0) // 코드1 x / 코드2 x ( 처음 속성 구슬 먹을 때)
            {
                player_element_code_1 = eaten_code; // 코드 1 에 먹은 구슬의 코드 들어감
                player_element = player_element_code_1; // 처음 속성 구슬 먹을 때 code1이 주속성
                Eat_SameElement = false;

            }
            else // 코드 1 x / 코드 2 o
            {
                if ((int)player_element_code_2 != eaten_code)
                {
                    player_element_code_1 = eaten_code; // 코드 1 에 먹은 구슬의 코드 들어감
                    Eat_SameElement = false;

                }
                else
                {
                    NoticeNum = 2;
                    //Debug.Log("같은 속성 무시");
                    //NoticeUI.text = "같은 속성은 무시합니다!";
                    //Invoke("RemoveNotice", 3f);

                    Eat_SameElement = true;
                }
            }
            
            //return player_element_code_1;
        }
        else // 코드 1 가득 참
        {
            if (player_element_code_2 == 0) // 코드1 o / 코드2 x
            {
                if((int)player_element_code_1 != eaten_code) // 5.1 을 가지고 있으면 5 구슬 못먹음
                {
                    player_element_code_2 = eaten_code;
                    Eat_SameElement = false;

                }
                else
                {
                    NoticeNum = 2;
                    //NoticeUI.text = "같은 속성은 무시합니다!";
                    //Invoke("RemoveNotice", 3f);

                    //Debug.Log("같은 속성 무시");
                    Eat_SameElement = true;

                }

            }
            else // 코드1 o / 코드2 o
            {
                NoticeNum = 3;
                //Debug.Log("속성 가득 참!");
                //NoticeUI.text = "속성이 가득 찼습니다!";
                //Invoke("RemoveNotice", 3f);

                IsFull = true;
            }
        }
        
        ChangeColor(player_element);// 주속성 색깔로 변경 ( 코드 2가 있으면 2 그대로 / 코드 2가 없으면 방금 먹은 코드1로 변경)
    }

    /* 색깔이 바뀌는 경우
     * 결국 주속성이 바뀔 때 색깔도 같이 변함
     * 1. 구슬 먹을 때(주속성이 변하는 경우)
     * 2. 주속성 바꿀 때
     * 3. 주속성 버릴 때
     * 
     * 해결방법
     * 1.Update 함수에서 계속 확인을 한다 (단점: Update 함수 계속 실행)
     * 2. 바뀌는 경우 사용되는 함수마다 changecolor(주속성) 을 넣어준다
     */

    void ChangeColor(double code) // 입력: 주속성 코드를 받아옴
    {
        switch ((int)code) // ( 더블 형식의 주속성을 정수 형태로 변환해서 받음 : 이유는 n.m 의 색은 n 색과 같기 때문)
        {
            case 1:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = Color.red;
                break;
            case 2:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = Color.blue;
                break;

            case 3:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = Color.green;
                break;

            case 4:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = Color.yellow;
                break;

            case 5:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = Color.gray;
                break;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        EffectList = GameObject.Find("EffectManager").gameObject;
        joystick_r = GameObject.Find("JoyStick_R").GetComponent<JoyStick_R>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Element")
        {
            eaten_element_code = col.gameObject.GetComponent<Element_code>().element_code; // 충돌한 속성 구슬 의 속성값 대입

            //Eat_Element();
            Eat_Element(eaten_element_code);
            //element(eaten_element_code);  // 문제 있음
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false); // 비활성화


            // 속성 꽉차면 체력 + 1
            if(player_element_code_1 != 0 && player_element_code_2 != 0)
            {
                Hp hp = GameObject.Find("Character").GetComponent<Hp>();
                if(hp.hp < 10)
                    hp.hp+= 0.5f;
                //Experience.experience ++;
                //Experience.score ++;
                EffectList.transform.GetChild(25).gameObject.transform.position = transform.position;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if(changingEffect)
        {
            EffectList.transform.GetChild(n).gameObject.transform.position = transform.position;
        }
        //color();
    }
}
