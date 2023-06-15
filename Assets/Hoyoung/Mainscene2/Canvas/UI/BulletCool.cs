using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletCool : MonoBehaviour
{
    Slider slCool;

    Player_Fire player_fire;

    public float Cool;

    // Start is called before the first frame update
    void Start()
    {
        slCool = GetComponent<Slider>();
        player_fire = GameObject.Find("Character").GetComponent<Player_Fire>();
        slCool.value = player_fire.CoolTime / 15;
        Cool = player_fire.CoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        slCool.value = player_fire.CoolTime / 15;
        Cool = player_fire.CoolTime;

    }
}
