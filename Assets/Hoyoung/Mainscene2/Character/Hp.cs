using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    /* Hp */
    // 문제 발생! 경험치 코드에서 모든 캐릭터의 경험치랑 Hp 를 관리 하다보니 하나의 통합된 경험치와 Hp 를 공유하는듯.. 아마 static 영향인지도
    public float hp = 10.0f;
    public bool dead = false;
    //public float potion_hp = 5.0f; // 포션 회복량

    // 총알 데미지
    public float damage = 1.0f;


    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Enemy_Bullet")
        {
            damage = col2.gameObject.GetComponent<EnemyDamage>().TowerDamage;

            hp -= damage;
        }
        
    }
}
