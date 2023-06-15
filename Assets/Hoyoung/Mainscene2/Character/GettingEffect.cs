using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingEffect : MonoBehaviour
{
    /*
    public GameObject GettingEffect_exp;
    public GameObject GettingEffect_fire;
    public GameObject GettingEffect_water;
    public GameObject GettingEffect_tree;
    public GameObject GettingEffect_gold;
    public GameObject GettingEffect_solid;
    */
    public int get_elementcode;


    public float lifetime = 1.0f;

    static public GameObject EffectList;
    int i;
    int j;

    /* 뭔가 문제 있음
     * 여러번 호출 되면 오류남
     */


    void Disabled()
    {
        EffectList.transform.GetChild(i).gameObject.SetActive(false);
    }



    void explosion_element()
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Element")
        {
            get_elementcode = other.gameObject.GetComponent<Element_code>().element_code;

            if (gameObject.GetComponent<Element>().IsFull != true) // 가득 차면 실행 x
            {
                if(gameObject.GetComponent<Element>().Eat_SameElement != true) // 같은거 먹어도 실행 x
                {
                    switch (get_elementcode)
                    {
                        case 1:
                            i = 19;
                            explosion_element();
                            //explosion_element(GettingEffect_fire);
                            break;
                        case 2:
                            i = 20;
                            explosion_element();
                            //explosion_element(GettingEffect_water);
                            break;
                        case 3:
                            i = 21;
                            explosion_element();
                            // explosion_element(GettingEffect_tree);
                            break;
                        case 4:
                            i = 22;
                            explosion_element();
                            //explosion_element(GettingEffect_gold);
                            break;
                        case 5:
                            i = 23;
                            explosion_element();
                            //explosion_element(GettingEffect_solid);
                            break;
                    }
                }
                
            }
            else
            {
                // 속성 가득 참

                if (EffectList.transform.GetChild(24).gameObject.activeSelf == true)
                {
                    EffectList.transform.GetChild(EffectManager.EffectCount).gameObject.SetActive(true);
                    EffectList.transform.GetChild(EffectManager.EffectCount).gameObject.transform.position = transform.position;

                }
                else if (EffectList.transform.GetChild(EffectManager.EffectCount).gameObject.activeSelf == true)
                {
                    EffectList.transform.GetChild(EffectManager.EffectCount + 1).gameObject.SetActive(true);
                    EffectList.transform.GetChild(EffectManager.EffectCount + 1).gameObject.transform.position = transform.position;
                }
                else if (EffectList.transform.GetChild(EffectManager.EffectCount + 1).gameObject.activeSelf == true)
                {
                    EffectList.transform.GetChild(EffectManager.EffectCount + 2).gameObject.SetActive(true);
                    EffectList.transform.GetChild(EffectManager.EffectCount + 2).gameObject.transform.position = transform.position;

                }
                else if (EffectList.transform.GetChild(EffectManager.EffectCount + 1).gameObject.activeSelf == true)
                {
                    EffectList.transform.GetChild(EffectManager.EffectCount + 3).gameObject.SetActive(true);
                    EffectList.transform.GetChild(EffectManager.EffectCount + 3).gameObject.transform.position = transform.position;

                }
                else if (EffectList.transform.GetChild(EffectManager.EffectCount + 3).gameObject.activeSelf == true)
                {
                    Debug.Log("모두 실행중");
                }

                EffectList.transform.GetChild(24).gameObject.SetActive(true);
                EffectList.transform.GetChild(24).gameObject.transform.position = transform.position;

            }
        }
        else if (other.gameObject.tag == "Food")
        {
            

            if (EffectList.transform.GetChild(24).gameObject.activeSelf == true)
            {
                EffectList.transform.GetChild(EffectManager.EffectCount).gameObject.SetActive(true);
                EffectList.transform.GetChild(EffectManager.EffectCount).gameObject.transform.position = transform.position;
                
            }
            else if(EffectList.transform.GetChild(EffectManager.EffectCount).gameObject.activeSelf == true)
            {
                EffectList.transform.GetChild(EffectManager.EffectCount+1).gameObject.SetActive(true);
                EffectList.transform.GetChild(EffectManager.EffectCount + 1).gameObject.transform.position = transform.position;
            }
            else if (EffectList.transform.GetChild(EffectManager.EffectCount + 1).gameObject.activeSelf == true)
            {
                EffectList.transform.GetChild(EffectManager.EffectCount + 2).gameObject.SetActive(true);
                EffectList.transform.GetChild(EffectManager.EffectCount + 2).gameObject.transform.position = transform.position;

            }
            else if (EffectList.transform.GetChild(EffectManager.EffectCount + 1).gameObject.activeSelf == true)
            {
                EffectList.transform.GetChild(EffectManager.EffectCount + 3).gameObject.SetActive(true);
                EffectList.transform.GetChild(EffectManager.EffectCount + 3).gameObject.transform.position = transform.position;

            }
            else if(EffectList.transform.GetChild(EffectManager.EffectCount + 3).gameObject.activeSelf == true)
            {
                Debug.Log("모두 실행중");
            }
            
            EffectList.transform.GetChild(24).gameObject.SetActive(true);
            EffectList.transform.GetChild(24).gameObject.transform.position = transform.position;
            
        }

        //Instantiate(GettingEffect_exp, transform.position, transform.rotation);
        //Destroy(GettingEffect_exp, lifetime);
    }

}
