using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerDamaged : MonoBehaviour
{
    public SpriteRenderer Render;

    //public GameObject DamagingBullet; // 플레이어의 현재 총알 데미지
    //float damaged = 0.0f; // 타워 때린 총알의 데미지

    //bool isStrengthened = false;

    //float StrengthenNum = 1.16f; // 상생 데미지 가중치?
    //float StrengthenNum2 = 1.16f; // 상생 데미지 가중치?
    //float StrengthenNum3 = 1.8f; // 상생 데미지 가중치?


    //const float WeakenNum = 1.16f; // 상극 데미지 가중치 / 속성 레벨 0
    //const float WeakenNum2 = 1.16f; // 상극 데미지 가중치 / 속성 레벨 1
    //const float WeakenNum3 = 1.8f; // 상극 데미지 가중치 / 속성 레벨 2

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy_Bullet")
        {
            OnDamaged();
        }
    }
    void OnDamaged()
    {
        gameObject.layer = 10; //10번은 Player Damaged 레이어
        Render.color = new Color(1, 1, 1, 0.4f);
        Invoke("Offdamaged", 1);
    }

    void Offdamaged()
    {
        gameObject.layer = 8; // 8번은 player 레이어
        Render.color = new Color(1, 1, 1, 1.0f);
    }
    
}
