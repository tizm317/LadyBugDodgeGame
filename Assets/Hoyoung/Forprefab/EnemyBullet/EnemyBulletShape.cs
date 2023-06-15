using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletShape : MonoBehaviour
{
    double code;
    public Sprite Red;
    public Sprite Blue;
    public Sprite Green;
    public Sprite Yellow;
    public Sprite Broken_yellow;
    public Sprite Purple;

    int bulletHP; // 변수
    int OriginalHp; // 상수

    // Start is called before the first frame update
    void Start()
    {
        OriginalHp = this.GetComponent<EnemyMissile_Move>().BulletHP;
    }

    // Update is called once per frame
    void Update()
    {
        code = this.GetComponentInParent<AttackSystem>().code;
        bulletHP = this.GetComponent<EnemyMissile_Move>().BulletHP;

        switch(code)
        {
            case 1 :
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Red;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Blue;
                break;
            case 3:
                // 목 속성
                // 크기 다른 투사체 대비 약 두배
                // 콜라이더 크기 증가
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Green;
                this.gameObject.transform.localScale = new Vector3 (1, 1, 1);
                this.gameObject.GetComponent<CircleCollider2D>().radius = 0.5f;
                break;
            case 4:
                this.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                if(bulletHP > OriginalHp * 0.5)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Yellow;
                    this.gameObject.GetComponent<CircleCollider2D>().radius = 0.4f;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Broken_yellow;
                    this.gameObject.transform.localScale *= 0.9f;
                    this.gameObject.GetComponent<CircleCollider2D>().radius = 0.4f;
                }
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Purple;
                break;
        }
    }
}
