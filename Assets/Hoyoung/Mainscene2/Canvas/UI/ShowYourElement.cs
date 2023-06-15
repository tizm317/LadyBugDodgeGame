using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowYourElement : MonoBehaviour
{
    Element element;

    public Sprite Fire;
    public Sprite Water;
    public Sprite Tree;
    public Sprite Gold;
    public Sprite Solid;
    public Sprite default_sprite;


    private void Start()
    {
        element = GameObject.Find("Character").GetComponent<Element>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeImage(element.player_element, 2); // 주속성 코드

        if (element.player_element == element.player_element_code_1) // 주속성이 code1 이면 부속성이 code2
        {
            ChangeImage(element.player_element_code_2, 3); // 부속성 코드
        }
        else // 부속성이 code1
        {
            ChangeImage(element.player_element_code_1, 3); // 부속성 코드

        }
    }

    void ChangeImage(double code, int i) 
    {
        switch ((int)code) // ( 더블 형식의 주속성을 정수 형태로 변환해서 받음 : 이유는 n.m 의 색은 n 색과 같기 때문)
        {

            case 1:
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = Fire;
                break;
            case 2:
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = Water;
                break;

            case 3:
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = Tree;
                break;

            case 4:
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = Gold;
                break;

            case 5:
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = Solid;
                break;

            default:
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = default_sprite;
                break;

        }

    }
}
