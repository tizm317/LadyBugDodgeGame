using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{

    public Text LevelText;
    public Text SkillPointText;
    public Text ScoreText;
    public Text MainElement_Lv;
    public Text SubElement_Lv;

    Element element;

    // Start is called before the first frame update
    void Start()
    {
        element = GameObject.Find("Character").gameObject.transform.GetComponent<Element>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SkillPointText.text = "SKILL POINTS " + Experience.skill_point;

        LevelText.text = "LV. " + Experience.level;
        ScoreText.text = "SCORE  " + Experience.score;

        ElementText();
    }

    void ElementText()
    {
        if (element.player_element != 0) // 주속성 있을 때
        {
            MainElement_Lv.text = "LV" + ((element.player_element - (int)element.player_element) * 10 + 1); // 주속성

            if (element.player_element == element.player_element_code_1) // code1 이 주속성일 때 , code2 가 부속성
            {
                if (element.player_element_code_2 != 0) // 부속성 있을 때
                    SubElement_Lv.text = "LV" + ((element.player_element_code_2 - (int)element.player_element_code_2) * 10 + 1); // 부속성 code2
                else
                    SubElement_Lv.text = "LV" + 0;
            }
            else // code2 가 주속성 일때
            {
                if (element.player_element_code_1 != 0)
                    SubElement_Lv.text = "LV" + ((element.player_element_code_1 - (int)element.player_element_code_1) * 10 + 1); // 부속성 code1
                else
                    SubElement_Lv.text = "LV" + 0;
            }
        }
        else // 주속성 없을 때, 당연히 부속성도 없음
            MainElement_Lv.text = SubElement_Lv.text = "LV" + 0;
    }
}
