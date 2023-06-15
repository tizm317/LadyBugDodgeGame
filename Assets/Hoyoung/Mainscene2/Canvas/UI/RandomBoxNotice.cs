using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomBoxNotice : MonoBehaviour
{
    public Text NoticeUI; // Notice : 플레이 화면에 알려주는 용도
    public float NoticeTime = 10f;


    // Update is called once per frame
    void Update()
    {
        RandomBox randombox = GameObject.Find("Button").GetComponent<RandomBox>();

        if(NoticeTime > 0.0f)
        {
            if (randombox.NotEnough == true )
            {
                NoticeUI.text = "랜덤 박스를 열려면 " + (randombox.PointsRequired - Experience.skill_point) + " 포인트 더 필요합니다.";
                NoticeTime -= Time.deltaTime;
            }
            else
            {
                if (randombox.num == 1)
                {
                    NoticeUI.text = "이동속도 증가";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 2)
                {
                    NoticeUI.text = "총알 발사 쿨다운 감소";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 3)
                {
                    NoticeUI.text = "자석 켜짐";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 4)
                {
                    NoticeUI.text = "이동속도 감소";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 5)
                {
                    NoticeUI.text = "총알 발사 쿨다운 증가";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 6)
                {
                    NoticeUI.text = "자석 꺼짐";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 7)
                {
                    NoticeUI.text = "꽝";
                    NoticeTime -= Time.deltaTime;
                }
                else if(randombox.num == 8)
                {
                    NoticeUI.text = "시야 증가";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 9)
                {
                    NoticeUI.text = "시야 감소";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 10)
                {
                    NoticeUI.text = "사정거리 증가";
                    NoticeTime -= Time.deltaTime;
                }
                else if (randombox.num == 11)
                {
                    NoticeUI.text = "사정거리 감소";
                    NoticeTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            NoticeTime = 10f;
            randombox.NotEnough = false;
            NoticeUI.text = "";
            randombox.num = 0;
        }
    }


   
}
