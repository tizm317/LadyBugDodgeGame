using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    /* 슬라이더 경험치바 테스트 */

    Slider slExp;
    float fSliderBarTime;
    int last_exp = 0; // 직전 경험치

    //타워 점수 10점 때문에 수정
    int exp = 0;
   
    void Start()
    {
        slExp = GetComponent<Slider>();
    }


    void Update()
    {
        if (slExp.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);


        
        if (Experience.levelup) // 레벨 업 할 때
        {
            //타워 점수 10점 때문에 수정
            //slExp.value += (10 * (Experience.level - 1) - Experience.exp) / (10.0f * (Experience.level - 1)); // 레벨 올라가면서 exp.level 값이 1 오르기 때문에 다시 내려서 맞춰줌
            slExp.value += (10 * (Experience.level - 1) - last_exp) / (10.0f * (Experience.level - 1)); // 레벨 올라가면서 exp.level 값이 1 오르기 때문에 다시 내려서 맞춰줌
            if (slExp.value >= 1) // exp 바 꽉 차면(레벨 업) 다시 0으로 바꿈 , 경험치 자체가 줄진 않음
            {
                slExp.value = 0; // exp 바 
                slExp.value += ((Experience.exp - last_exp) - ((10 * (Experience.level - 1) - last_exp))) / (10.0f * (Experience.level));
                exp = (Experience.exp - last_exp) - (10 * (Experience.level - 1) - last_exp);
                last_exp = 0; // 전 경험치도 비워주어야 정상 작동
                //Experience.experience -= 10 * Experience.level;
                Experience.experience = 0; // 기존에는 Experience 스크립트에서 0으로 바꿨는데 바꿈
                Experience.levelup = false; // 레벨 업이 끝났기 때문에 false로 바꿔줌
            }
            //타워 점수 10점 때문에 수정
            Experience.experience = exp;
            last_exp = exp;
        }
        else
        {
            if (Experience.experience > last_exp) // 경험치 오를때마다 (더 좋은 방법이 있을거같은데 생각안남)
            {
                slExp.value += (Experience.experience - last_exp) / (10.0f * Experience.level);
                last_exp = Experience.experience; // 현재 경험치를 전 경험치에 입력
            }
        }



    }
}
