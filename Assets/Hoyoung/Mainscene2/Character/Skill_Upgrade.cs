using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Skill_Upgrade : MonoBehaviour
{
    static public GameObject EffectList;
    int i = 25; // skill level up effect : 25


    public GameObject player;

    //public double code_1 = 0;
    //public double code_2 = 0;
    public double code = 0;

    public bool upgrade_bool = false; // 스킬 업그레이드 여부

    int needpoint = 1;

    /* 총알 발사중일 때 버튼 x */
    JoyStick_R joystick_r;

    void Disabled()
    {
        EffectList.transform.GetChild(i).gameObject.SetActive(false);
    }

    void Skill_LV_Effect()
    {
        //Instantiate(element, transform.position, transform.rotation);
        //Destroy(element, lifetime);

        EffectList.transform.GetChild(i).gameObject.SetActive(true);
        EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;
        Invoke("Disabled", 1);

    }

    private void Start()
    {
        EffectList = GameObject.Find("EffectManager").gameObject;
        joystick_r = GameObject.Find("JoyStick_R").GetComponent<JoyStick_R>();
    }

    public void Skill_Upgrade_Button() // 눌렀을 때 반응
    {
        if (Pause.IsPause == false)
        {
            //code_1 = player.transform.GetComponent<Element>().player_element_code_1;
            //code_2 = player.transform.GetComponent<Element>().player_element_code_2;
            code = player.transform.GetComponent<Element>().player_element;

            // 속성 레벨별로 필요한 포인트 다르게
            if (code == 1 || code == 2 || code == 3 || code == 4 || code == 5)
                needpoint = 1;
            else if (code == 1.1 || code == 2.1 || code == 3.1 || code == 4.1 || code == 5.1)
                needpoint = 2;
            else if (code == 1.2 || code == 2.2 || code == 3.2 || code == 4.2 || code == 5.2 || code == 0)
                needpoint = 0;

            if (Experience.skill_point >= needpoint) // 스킬 포인트가 존재하면
            {
                if (joystick_r.IsShooting == false)
                {
                    switch (code)
                    {
                        case 1:
                            code = 1.1;
                            Experience.skill_point -= needpoint; // 스킬포인트 레벨업에 써서 감소
                            Skill_LV_Effect();
                            upgrade_bool = true;
                            break;
                        case 1.1:
                            code = 1.2;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 1.2:
                            GameObject.Find("Character").GetComponent<Element>().NoticeNum = 4;
                            //NoticeUI.text = "속성 최고 레벨 입니다!";
                            //Invoke("RemoveNotice", 3f);
                            //Debug.Log("최종 단계입니다."); // 최종 단계는 스킬 포인트 감소 안됨
                            break;
                        case 2:
                            code = 2.1;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 2.1:
                            code = 2.2;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 2.2:
                            GameObject.Find("Character").GetComponent<Element>().NoticeNum = 4;
                            //NoticeUI.text = "속성 최고 레벨 입니다!";
                            //Invoke("RemoveNotice", 3f);
                            //Debug.Log("최종 단계입니다.");
                            break;
                        case 3:
                            code = 3.1;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 3.1:
                            code = 3.2;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 3.2:
                            GameObject.Find("Character").GetComponent<Element>().NoticeNum = 4;
                            //NoticeUI.text = "속성 최고 레벨 입니다!";
                            //Invoke("RemoveNotice", 3f);
                            //Debug.Log("최종 단계입니다.");
                            break;
                        case 4:
                            code = 4.1;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 4.1:
                            code = 4.2;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 4.2:
                            GameObject.Find("Character").GetComponent<Element>().NoticeNum = 4;
                            //NoticeUI.text = "속성 최고 레벨 입니다!";
                            //Invoke("RemoveNotice", 3f);
                            //Debug.Log("최종 단계입니다.");
                            break;
                        case 5:
                            code = 5.1;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 5.1:
                            code = 5.2;
                            Experience.skill_point -= needpoint;
                            upgrade_bool = true;
                            Skill_LV_Effect();

                            break;
                        case 5.2:
                            GameObject.Find("Character").GetComponent<Element>().NoticeNum = 4;
                            //NoticeUI.text = "속성 최고 레벨 입니다!";
                            //Invoke("RemoveNotice", 3f);
                            //Debug.Log("최종 단계입니다.");
                            break;
                        case 0:
                            GameObject.Find("Character").GetComponent<Element>().NoticeNum = 5;
                            //NoticeUI.text = "업그레이드 할 속성이 없습니다!";
                            //Invoke("RemoveNotice", 3f);
                            //Debug.Log("속성이 없습니다!");
                            break;
                    }
                    //player.transform.GetComponent<Element>().player_element_code_1 = code_1; // 플레이어 코드에 레벨업된 코드 넣어줌

                    /* 레벨 업 한 코드 다시 넣어주어야 함 */
                    player.transform.GetComponent<Element>().player_element = code;
                    if ((int)code == (int)player.transform.GetComponent<Element>().player_element_code_1) // 주속성이 code1 , 업그레이드 한게 주속성이므로 code1 도 업그레이드
                        player.transform.GetComponent<Element>().player_element_code_1 = code;
                    else if ((int)code == (int)player.transform.GetComponent<Element>().player_element_code_2) // 주속성이 code2
                        player.transform.GetComponent<Element>().player_element_code_2 = code;
                }

            }
            else
            {
                GameObject.Find("Character").GetComponent<Element>().NoticeNum = 6;
                //NoticeUI.text = "스킬 포인트가 부족합니다!";
                //Invoke("RemoveNotice", 3f);
                //Debug.Log("스킬 포인트가 부족합니다!!!");
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (upgrade_bool == true) // 스킬 레벨 업 한 후 / 업그레이드 여부
        {
           
            upgrade_bool = false; // 업그레이드 여부 초기화
            if (Experience.skill_point < 1) // 스킬 포인트 다 썼을 경우
            {
                GameObject.Find("Character").GetComponent<Element>().NoticeNum = 7;
                //NoticeUI.text = "스킬 포인트를 다 썼습니다!";
                //Invoke("RemoveNotice", 3f);
                //Debug.Log("스킬 포인트를 다 썼습니다!!!!!");
                //Upgrade_Button.GetComponent<Button>().interactable = false;
                //Element_1.SetActive(false); // 비활성화
                //Element_2.SetActive(false);
            }
        }
    }
}
