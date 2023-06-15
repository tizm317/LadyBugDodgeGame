using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSprite : MonoBehaviour
{
    public Sprite RedFront;
    public Sprite RedBack;

    public Sprite BlueFront;
    public Sprite BlueBack;
    
    public Sprite GreenFront;
    public Sprite GreenBack;
    
    public Sprite YellowFront;
    public Sprite YellowBack;
    
    public Sprite PurpleFront;
    public Sprite PurpleBack;

    GameObject pos;

    int num = 0;

    //bool finished = false;

    private void OnEnable()
    {
        // 생길 때 무슨 속성인지

        if (this.transform.parent.gameObject.name == "Red Ant(Clone)")
            num = 1;
        else if (this.transform.parent.gameObject.name == "Blue Butterfly(Clone)")
            num = 2;
        else if (this.transform.parent.gameObject.name == "Green Snail(Clone)")
            num = 3;
        else if (this.transform.parent.gameObject.name == "Yellow Bee(Clone)")
            num = 4;
        else if (this.transform.parent.gameObject.name == "Purple Spider(Clone)")
            num = 5;

        // 생기는 위치로 앞, 뒤 구분
        // 1,2,3,4 까지 앞
        // 5,6,7,8 은 뒤

            pos = this.transform.parent.parent.parent.gameObject;

            if (pos.name == "ground 1" || pos.name == "ground 2" || pos.name == "ground 3" || pos.name == "ground 4")
            {
                switch (num)
                {
                    case 1:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = RedFront;
                        break;
                    case 2:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = BlueFront;
                        break;
                    case 3:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = GreenFront;
                        break;
                    case 4:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = YellowFront;
                        break;
                    case 5:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = PurpleFront;
                        break;
                }
            }
            else
            {
                switch (num)
                {
                    case 1:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = RedBack;
                        break;
                    case 2:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = BlueBack;
                        break;
                    case 3:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = GreenBack;
                        break;
                    case 4:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = YellowBack;
                        break;
                    case 5:
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = PurpleBack;
                        break;
                }
            }
    }
   
}
