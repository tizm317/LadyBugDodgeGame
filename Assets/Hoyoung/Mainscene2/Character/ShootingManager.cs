using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    double code = 0.0;

    //int count;
    //GameObject[] FireArray;

    //public GameObject MissileLocation;

    // Start is called before the first frame update
    void Start()
    {
            //FireArray = new GameObject[count];
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.GetComponent<Element>())
            code = transform.GetComponent<Element>().player_element;
        switch ((int)code)
        {
            case 0: // 기본 속성
                transform.GetComponent<Player_Fire>().enabled = true;
                //transform.player_fire();
                break;
            case 1: // 화
                //BulletFire();
                break;
            case 2: // 수
                break;
            case 3: // 목
                break;
            case 4: // 금
                break;
            case 5: // 토
                break;
        }
    }
}
