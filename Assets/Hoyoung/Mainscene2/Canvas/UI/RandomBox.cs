using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class RandomBox : MonoBehaviour
{
    static public GameObject EffectList;


    bool code1Max = false;
    bool code2Max = false;
    public bool RandomBoxPlayed = false;
    public int PointsRequired = 3;
    public bool NotEnough = false;
    public int num = 0;

    //자석
    public bool magnetPlay = false;

    //시야
    public bool Sight = false;

    private void Start()
    {
        EffectList = GameObject.Find("EffectManager").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Element element = GameObject.Find("Character").GetComponent<Element>();

        if (element.player_element_code_1 == 1.2 || element.player_element_code_1 == 2.2 || element.player_element_code_1 == 3.2 || element.player_element_code_1 == 4.2 || element.player_element_code_1 == 5.2)
            code1Max = true;
        else
            code1Max = false;

        if (element.player_element_code_2 == 1.2 || element.player_element_code_2 == 2.2 || element.player_element_code_2 == 3.2 || element.player_element_code_2 == 4.2 || element.player_element_code_2 == 5.2)
            code2Max = true;
        else
            code2Max = false;


        if (code1Max && code2Max)
        {
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(3).gameObject.SetActive(false);
        }


        //시야 on : size 6 -> 7
        // 조건: sight == true 이고 size <= 7 
        if(Sight && GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize <= 7)
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize += Time.deltaTime;

        //시야 off
        // 조건: sight == false 이고 size > 6
        if(Sight == false && GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize > 6)
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize -= Time.deltaTime;
    }

    void Disabled()
    {
        EffectList.transform.GetChild(25).gameObject.SetActive(false);
    }

    void Skill_LV_Effect()
    {
        //Instantiate(element, transform.position, transform.rotation);
        //Destroy(element, lifetime);

        EffectList.transform.GetChild(25).gameObject.SetActive(true);
        EffectList.transform.GetChild(25).gameObject.transform.position = GameObject.Find("RandomBoxNotice").transform.position;
        Invoke("Disabled", 1);

    }

    public void RandomItem()
    {


        if (Experience.skill_point >= PointsRequired)
        {
            // 포인트 소모 : 0 -> 3 -> 6 -> 9
            Experience.skill_point -= PointsRequired;
            RandomBoxPlayed = true;
            PointsRequired += 3;

            Player_Fire player_Fire = GameObject.Find("Character").GetComponent<Player_Fire>();

            //UnityEngine.Random.Range(1,8)
            switch (UnityEngine.Random.Range(1, 6))
            {
                case 1:
                    // 이동속도 증가
                    if (Joy_stick.speed <4f)
                    {
                        Skill_LV_Effect();
                        Joy_stick.speed += 0.2f;
                        num = 1;
                    }
                    else
                        num = 7;
                    break;

                //case 2:
                //    // 총알 발사 쿨다운 감소
                //    if (player_Fire.Cool < 2f)
                //    {
                //        player_Fire.Cool += 0.2f;
                //        num = 2;
                //    }
                //    else
                //        num = 7;
                //    break;
                case 2:
                    // 자석 on
                    
                    if (magnetPlay == false)
                    {
                        Skill_LV_Effect();
                        magnetPlay = true;
                        num = 3;
                    }
                    else
                        num = 7;
                    break;

                //case 4:
                //    // 이동속도 감소
                //    if (Joy_stick.speed > 2.4f)
                //    {
                //        Joy_stick.speed -= 0.2f;
                //        num = 4;
                //    }
                //    else
                //        num = 7;
                //    break;

                //case 5:
                //    // 총알 발사 쿨다운 증가
                //    if (player_Fire.Cool > 1f)
                //    {
                //        player_Fire.Cool -= 0.2f;
                //        num = 5;
                //    }
                //    else
                //        num = 7;
                //    //player_Fire.Cool -= 0.1f;
                //    //num = 5;
                //    break;
                //case 6:
                //    // 자석 off
                //    // 자석 on 인 경우만
                //    if (magnetPlay == true)
                //    {
                //        magnetPlay = false;
                //        num = 6;
                //    }
                //    else
                //        num = 7;
                //    break;
                //case 3:
                //    // 꽝
                //    num = 7;
                //    break;
                case 3:
                    // 시야 on
                    // 기본 시야인 경우만, 아닐 시 꽝
                    if (Sight == false)
                    {
                        Skill_LV_Effect();
                        Sight = true;
                        num = 8;
                    }
                    else
                        num = 7;
                    break;
                //case 9:
                //    // 시야 off
                //    // 시야가 넓혀진 경우에만 , 아닐 시 꽝
                //    if (Sight)
                //    {
                //        Sight = false;
                //        num = 9;
                //    }
                //    else
                //        //꽝
                //        num = 7;
                //    break;
                case 4:
                    // 사정거리 // 최대 2 그 이상은 꽝
                    if (player_Fire.FireDelay < 2)
                    {
                        Skill_LV_Effect();
                        player_Fire.FireDelay += 0.2f;
                        num = 10;
                    }
                    else 
                        num = 7;
                    break;
                //case 11:
                //    // 사정거리 // 최소 0.5 그 이하는 꽝
                //    if (player_Fire.FireDelay > 0.5)
                //    {
                //        player_Fire.FireDelay -= 0.2f;
                //        num = 11;
                //    }
                //    else
                //        num = 7;
                //    break;
            }
        }
        else
        {
            NotEnough = true;
            //Debug.Log("랜덤 박스를 열려면 " + PointsRequired + " 만큼 필요합니다.");
            // PointsRequired 알려줌
            // 부족하다고 알림
        }
    }


    
}
