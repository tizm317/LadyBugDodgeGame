using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // button 사용하려면 UI 필요

public class Skill_Point : Skill_Upgrade // 스킬 업그레이드 상속 받음
{

    // Update is called once per frame
    void Update()
    {
      //if(Experience.skill_point != 0)
      //      Upgrade_Button.GetComponent<Button>().interactable = true;

        if (upgrade_bool == true) // 스킬 레벨 업 한 후 / 업그레이드 여부
        {
            upgrade_bool = false; // 업그레이드 여부 초기화
            if (Experience.skill_point < 1) // 스킬 포인트 다 썼을 경우
            {
                //Debug.Log("스킬 포인트를 다 썼습니다");
                //Upgrade_Button.GetComponent<Button>().interactable = false;
                //Element_1.SetActive(false); // 비활성화
                //Element_2.SetActive(false);
            }
      }
            
        
    }
}
