using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Night : MonoBehaviour
{
    public Text timeText;
    float Timer = 10;

    public GameObject Lit;
    public GameObject Spot_lit;
    public GameObject DayTime;
    public GameObject NightTime;

    public GameObject time_effect;
    public GameObject player;
    //float lifetime = 1.0f;

    bool IsNight = false;

    public Slider slTimer;

    //하늘 배경용
    Camera cam;
    Color Originalcolor; // 낮 하늘

    void Disabled()
    {
        GameObject.Find("EffectManager").transform.GetChild(16).gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 하늘 배경
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Originalcolor = cam.backgroundColor;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Lit.GetComponent<Light>().intensity -= Time.deltaTime / 10;
        if (Timer > 0)
        {
            
            if (IsNight)
            {
                Timer -= Time.deltaTime;

                //밤 -> 낮
                slTimer.value = 10 - Timer;
                
                // 밤 하늘
                cam.backgroundColor = Color.black;

            }
            else
            {
                Timer -= Time.deltaTime / 6;
                //낮 -> 밤
                slTimer.value = Timer;

                // 낮 하늘
                cam.backgroundColor = Originalcolor;

            }

        }
        else
        {
            Timer = 10;
            if(IsNight)
            {
                //밤 -> 낮
                GameObject.Find("EffectManager").transform.GetChild(16).gameObject.transform.position = player.transform.position;
                GameObject.Find("EffectManager").transform.GetChild(16).gameObject.SetActive(true);

                Invoke("Disabled", 1);
                //Time_Effect();
                Lit.SetActive(true);
                Spot_lit.SetActive(false);
                IsNight = false;
            }
            else
            {
                GameObject.Find("EffectManager").transform.GetChild(16).gameObject.transform.position = player.transform.position;

                GameObject.Find("EffectManager").transform.GetChild(16).gameObject.SetActive(true);
                Invoke("Disabled", 1);

                //Time_Effect();
                //낮 -> 밤
                Lit.SetActive(false);
                Spot_lit.SetActive(true);
                IsNight = true;
            }
            
        }

    }
}
