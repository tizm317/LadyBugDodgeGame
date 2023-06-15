using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Notice : MonoBehaviour
{
    public Text NoticeUI; // Notice : 플레이 화면에 알려주는 용도
    int NoticeNum;

    public float NoticeTime = 3f;

    // NoticeOff 가 실행되는 도중에 다른 알림으로 바뀌는 경우 시간 다시 리셋하기 위한 변수
    int lastNum;

    // Update is called once per frame
    void Update()
    {

        NoticeNum = GameObject.Find("Character").GetComponent<Element>().NoticeNum;

        // stage notice
        TowerSpawn towerspawn = GameObject.Find("Map Example").GetComponent<TowerSpawn>();
        if (towerspawn.StageUp == true)
            NoticeNum = 9;

        

        switch (NoticeNum)
        {
            case 1:
                //Debug.Log(lastNum);
                //Debug.Log(NoticeNum);
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    // NoticeOff 가 실행되는 도중에 다른 알림으로 바뀌는 경우 시간 다시 리셋
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "속성이 하나 이하면 버릴 수 없습니다";
                NoticeOff();
                break;
            case 2:
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "같은 속성은 무시합니다";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                NoticeOff();
                break;
            case 3:
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "속성이 가득 찼습니다";
                NoticeOff();
                break;
            case 4:
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "속성 최고 레벨 입니다";
                NoticeOff();
                break;
            case 5:
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "업그레이드 할 속성이 없습니다";
                NoticeOff();
                break;
            case 6:
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "스킬 포인트가 부족합니다";
                NoticeOff();
                break;
            case 7:
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "스킬 포인트를 다 썼습니다";
                NoticeOff();
                break;
            case 8:
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Bold;
                NoticeUI.text = "속성이 두개여야 바꿀 수 있습니다";
                NoticeOff();
                break;
            case 9:
                // stage notice
                if (lastNum != 0 && lastNum != NoticeNum)
                {
                    NoticeTime = 3f;
                    lastNum = NoticeNum;
                }
                NoticeUI.fontStyle = FontStyle.Normal;
                if(towerspawn.stage == 5)
                    NoticeUI.text = "S T A G E 5  !  5 스테이지 뒤에 물과 불 속성 몬스터가 나옵니다.";
                else if(towerspawn.stage == 10)
                    NoticeUI.text = "S T A G E 10  !  5 스테이지 뒤에 나무와 전기 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 15)
                    NoticeUI.text = "S T A G E 15  !  5 스테이지 뒤에 땅과 불 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 20)
                    NoticeUI.text = "S T A G E 20  !  5 스테이지 뒤에 물과 나무 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 25)
                    NoticeUI.text = "S T A G E 25  !  5 스테이지 뒤에 땅과 전기 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 30)
                    NoticeUI.text = "S T A G E 30  !  5 스테이지 뒤에 나무와 땅 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 35)
                    NoticeUI.text = "S T A G E 35  !  5 스테이지 뒤에 물과 전기 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 40)
                    NoticeUI.text = "S T A G E 40  !  5 스테이지 뒤에 불과 나무 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 45)
                    NoticeUI.text = "S T A G E 45  !  5 스테이지 뒤에 물과 땅 속성 몬스터가 나옵니다.";
                else if (towerspawn.stage == 50)
                    NoticeUI.text = "S T A G E 50  !  5 스테이지 뒤에 불과 전기 속성 몬스터가 나옵니다.";
                else
                {
                    NoticeUI.text = "S T A G E  " + towerspawn.stage;
                }
                NoticeOff();
                break;
            
        }
        if (NoticeTime <= 0.0f)
        {
            NoticeTime = 3f;
            GameObject.Find("Character").GetComponent<Element>().NoticeNum = 0;
            lastNum = 0;
        }
    }

    

    void NoticeOff()
    {
        // NoticeOff가 실행되는 도중 다른 알림으로 바뀔때
        lastNum = NoticeNum;
        
        
        if (NoticeTime <= 0.1f)
        {
            //stage notice
            TowerSpawn towerspawn = GameObject.Find("Map Example").GetComponent<TowerSpawn>();
            NoticeUI.fontStyle = FontStyle.Normal;
            if (towerspawn.stage == 5)
                NoticeUI.text = "S T A G E 5  !  5 스테이지 뒤에 물과 불 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 10)
                NoticeUI.text = "S T A G E 10  !  5 스테이지 뒤에 나무와 전기 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 15)
                NoticeUI.text = "S T A G E 15  !  5 스테이지 뒤에 땅과 불 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 20)
                NoticeUI.text = "S T A G E 20  !  5 스테이지 뒤에 물과 나무 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 25)
                NoticeUI.text = "S T A G E 25  !  5 스테이지 뒤에 땅과 전기 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 30)
                NoticeUI.text = "S T A G E 30  !  5 스테이지 뒤에 나무와 땅 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 35)
                NoticeUI.text = "S T A G E 35  !  5 스테이지 뒤에 물과 전기 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 40)
                NoticeUI.text = "S T A G E 40  !  5 스테이지 뒤에 불과 나무 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 45)
                NoticeUI.text = "S T A G E 45  !  5 스테이지 뒤에 물과 땅 속성 몬스터가 나옵니다.";
            else if (towerspawn.stage == 50)
                NoticeUI.text = "S T A G E 50  !  5 스테이지 뒤에 불과 전기 속성 몬스터가 나옵니다.";
            else
            {
                NoticeUI.text = "S T A G E  " + towerspawn.stage;
            }
        }
        NoticeTime -= Time.deltaTime;

    }
}
