using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // 타워의 현재 데미지를 타워 총알에 적용 시켜줌
    // 플레이어의 Hp 스크립트는 타워 총알과 충돌 하기 때문에 이 값을 따라 데미지를 입음

    public float TowerDamage;
    public float Towercode;

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInParent<TowerStatusBlue>())
        {
            TowerDamage = this.GetComponentInParent<TowerStatusBlue>().CurrentAttackDamage;
            Towercode = this.GetComponentInParent<TowerStatusBlue>().code;
        }
        else if (this.GetComponentInParent<TowerStatusRed>())
        {
            TowerDamage = this.GetComponentInParent<TowerStatusRed>().CurrentAttackDamage;
            Towercode = this.GetComponentInParent<TowerStatusRed>().code;
        }
        else if (this.GetComponentInParent<TowerStatusYellow>())
        {
            TowerDamage = this.GetComponentInParent<TowerStatusYellow>().CurrentAttackDamage;
            Towercode = this.GetComponentInParent<TowerStatusYellow>().code;
        }
        else if (this.GetComponentInParent<TowerStatusGreen>())
        {
            TowerDamage = this.GetComponentInParent<TowerStatusGreen>().CurrentAttackDamage;
            Towercode = this.GetComponentInParent<TowerStatusGreen>().code;
        }
        else if (this.GetComponentInParent<TowerStatusPurple>())
        {
            TowerDamage = this.GetComponentInParent<TowerStatusPurple>().CurrentAttackDamage;
            Towercode = this.GetComponentInParent<TowerStatusPurple>().code;
        }
    }
}
