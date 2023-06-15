using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBulletEffectFX : MonoBehaviour
{
    /*
    public GameObject explosion_fire;

    public GameObject explosion_fire1;
    public GameObject explosion_fire2;
    public GameObject explosion_fire3;
    public GameObject explosion_water1;
    public GameObject explosion_water2;
    public GameObject explosion_water3;
    public GameObject explosion_tree1;
    public GameObject explosion_tree2;
    public GameObject explosion_tree3;
    public GameObject explosion_gold1;
    public GameObject explosion_gold2;
    public GameObject explosion_gold3;
    public GameObject explosion_solid1;
    public GameObject explosion_solid2;
    public GameObject explosion_solid3;
    */
    public float lifetime = 1.0f;

    double bulletcode = 0;
    
    static public GameObject EffectList;

    int i;

    //bool IsDisabled = false;

    void Disabled()
    {
        EffectList.transform.GetChild(i).gameObject.SetActive(false);
        //Debug.Log("기본 비활성화");
    }
   

    private void Start()
    {
        EffectList = GameObject.Find("EffectManager").gameObject;
    }

    private void ChangePosition()
    {
        EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attacking_Bullet")
        {
            bulletcode = other.gameObject.GetComponent<BulletCode>().code;
            switch (bulletcode)
            {
                case 1:
                    i = 1;
                    ChangePosition();
                    //EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;
                    //EffectList.transform.GetChild(i).gameObject.transform.rotation = transform.rotation;

                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    
                    
                    Invoke("Disabled", 1);
                    
                    //EffectManager.instance.GetEffect(transform.position);
                    //explosion_element(explosion_fire1);
                    break;
                case 1.1:
                    i = 2;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_fire2);
                    break;
                case 1.2:
                    i = 3;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_fire3);
                    break;
                case 2:
                    i = 4;
                    ChangePosition();
                    //EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;

                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_water1);
                    break;
                case 2.1:
                    i = 5;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_water2);
                    break;
                case 2.2:
                    i = 6;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_water3);
                    break;
                case 3:
                    i = 7;
                    ChangePosition();
                    //EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;
                
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_tree1);
                    break;
                case 3.1:
                    i = 8;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_tree2);
                    break;
                case 3.2:
                    i = 9;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_tree3);
                    break;
                case 4:
                    i = 10;
                    ChangePosition();
                    //EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;

                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_gold1);
                    break;
                case 4.1:
                    i = 11;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_gold2);
                    break;
                case 4.2:
                    i = 12;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                   // explosion_element(explosion_gold3);
                    break;

                case 5:
                    i = 13;
                    ChangePosition();
                    //EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;

                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_solid1);
                    break;
                case 5.1:
                    i = 14;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_solid2);
                    break;
                case 5.2:
                    i = 15;
                    ChangePosition();
                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_solid3);
                    break;

                default:
                    i = 0;
                    ChangePosition();
                    //EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;

                    EffectList.transform.GetChild(i).gameObject.SetActive(true);
                    Invoke("Disabled", 1);
                    //explosion_element(explosion_fire);
                    break;
            }

        }
        
    }
}

