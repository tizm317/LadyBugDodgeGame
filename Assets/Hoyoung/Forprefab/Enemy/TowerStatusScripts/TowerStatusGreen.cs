using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatusGreen : MonoBehaviour
{
    public int ArrayIndex;
    
    public float code = 3f;


    public float TowerHP = 100.0f; // 타워의 현재 체력 
    public float TowerShootingSpeed = 1.0f; // 타워의 현재 슈팅 스피드 

    const float TowerAttackDamage = 1.0f; // 타워 오리지널 데미지 (상수)
    public float CurrentAttackDamage = TowerAttackDamage; // 타워의 현재 데미지

    public int TowerLevel = 1; //타워의 현재 레벨
    //public float TowerSpawnDelay = 10; // 타워 사망 후 생성 딜레이
    //public int AliveTowerNumber; //살아있는 타워 수
    public int PlusTowerScore;

    public GameObject DamagingBullet; // 플레이어의 현재 총알
    float damaged = 0.0f; // 타워 때린 총알의 데미지

    float StrengthenNum = 2f; // 상생 데미지 가중치?
    float StrengthenNum2 = 2f; // 상생 데미지 가중치?
    float StrengthenNum3 = 2f; // 상생 데미지 가중치?

    const float WeakenNum = 2f; // 상극 데미지 가중치 / 속성 레벨 0
    const float WeakenNum2 = 2f; // 상극 데미지 가중치 / 속성 레벨 1
    const float WeakenNum3 = 2f; // 상극 데미지 가중치 / 속성 레벨 2

    //public GameObject TowerDestroyingEffect;
    GameObject EffectList;

    public bool isDamaged = false;
    public bool isDestroyed = false;

    public bool isStrengthened = false; // 상생으로 인해 강화되었는지
    public bool isStrengthened2 = false; // 상생으로 인해 강화되었는지
    public bool isStrengthened3 = false; // 상생으로 인해 강화되었는지

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attacking_Bullet")
        {

            DamagingBullet = collision.gameObject; // 타워 때린 총알

            damaged = DamagingBullet.GetComponent<BulletCode>().damage;

            // 상성 가중치

            //상생 : 금생수
            System1();
            //상극 : 토극수
            System2();


            isDamaged = true;
            TowerHP -= damaged;
        }
    }


    void System1()
    {
        // 1. 상생 
        // 수생목
        if (DamagingBullet.GetComponent<BulletCode>().code == 2)
        {
            // 기본 데미지 입음

            // 타워 공격력 강화
            if (isStrengthened == false) // 1번만 실행
            {
                CurrentAttackDamage = CurrentAttackDamage * StrengthenNum; // 1.1 배 강화됨
                isStrengthened = true;
                GameObject.Find("BuffManager").GetComponent<BuffManager>().BuffEffect(this.transform);
            }
        }
        else if (DamagingBullet.GetComponent<BulletCode>().code == 2.1)
        {
            if (isStrengthened2 == false) // 1번만 실행
            {
                CurrentAttackDamage = CurrentAttackDamage * StrengthenNum2; // 1.1 배 강화됨
                isStrengthened2 = true;
                GameObject.Find("BuffManager").GetComponent<BuffManager>().BuffEffect(this.transform);
            }
        }
        else if (DamagingBullet.GetComponent<BulletCode>().code == 2.2)
        {
            if (isStrengthened3 == false) // 1번만 실행
            {
                CurrentAttackDamage = CurrentAttackDamage * StrengthenNum3; // 1.1 배 강화됨
                isStrengthened3 = true;
                GameObject.Find("BuffManager").GetComponent<BuffManager>().BuffEffect(this.transform);

            }
        }

    }

    void System2()
    {
        // 2. 상극 
        // 금극목
        if (DamagingBullet.GetComponent<BulletCode>().code == 4)
        {

            damaged *= WeakenNum; // 10 * 1.1
            GameObject.Find("BuffManager").GetComponent<BuffManager>().DebuffEffect(this.transform);
        }
        else if (DamagingBullet.GetComponent<BulletCode>().code == 4.1)
        {
            damaged *= WeakenNum2; // 20 * 1.2 배
            GameObject.Find("BuffManager").GetComponent<BuffManager>().DebuffEffect(this.transform);
        }
        else if (DamagingBullet.GetComponent<BulletCode>().code == 4.2)
        {
            damaged *= WeakenNum3; // 30 * 1.3 배
            GameObject.Find("BuffManager").GetComponent<BuffManager>().DebuffEffect(this.transform);
        }

    }

    void TowerDie() //타워죽음 함수
    {
        Destroy(this.gameObject);  // 오브젝트 제거
        GameObject.Find("Map Example").GetComponent<TowerSpawn>().Place[ArrayIndex] = null; //배열에서도 지워야함


        //AliveTowerNumber--;  // 살아있는 타워 넘버에서 하나 빼기
        //GameObject.Find("Map Example").GetComponent<TowerSpawn>().TowerCount = AliveTowerNumber;

        TowerSpawn towerspawn = GameObject.Find("Map Example").GetComponent<TowerSpawn>();
        towerspawn.TowerCount--;

        //Experience.score += (10 + TowerLevel -1);  // 타워부숴질때 10점 더하기 (누적 경험치 / score)
        //Experience.experience += (10 + TowerLevel -1);  // 타워부숴질때 10점 더하기 (경험치)
        Experience.score += 10 * TowerLevel;  // 타워부숴질때 10점 더하기 (누적 경험치 / score)
        Experience.experience += 10 * TowerLevel;  // 타워부숴질때 10점 더하기 (경험치)

        //Instantiate(TowerDestroyingEffect, transform.position, transform.rotation);  // 타워부숴지기 이펙트 실행
        EffectList.transform.GetChild(46).gameObject.SetActive(true);
        EffectList.transform.GetChild(46).gameObject.transform.position = transform.position;
        Invoke("Disabled", 1);
    }

    private void Start()
    {
        // TowerSpawn 스크립트에서 몇번째 index인지 받아옴
        // 타워 부숴질 때 TowerSpawn 의 배열에서도 비워줘야 하기 때문에
        ArrayIndex = GameObject.Find("Map Example").GetComponent<TowerSpawn>().PlaceRanNum;

        // 타워 레벨
        TowerSpawn towerspawn = GameObject.Find("Map Example").GetComponent<TowerSpawn>();

        if (towerspawn.stage <= 8)
        {
            TowerLevel = 1;
            TowerHP = 50.0f;
        }
        else if (towerspawn.stage <= 16)
        {
            TowerHP = 80.0f;
            if (towerspawn.stage == 10 || towerspawn.stage == 15)
                TowerHP = 100.0f;
            TowerLevel = 2;
        }
        else if (towerspawn.stage <= 24)
        {
            TowerHP = 100.0f;
            if (towerspawn.stage == 20 || towerspawn.stage == 25)
                TowerHP = 120.0f;
            TowerLevel = 3;
        }
        else if (towerspawn.stage <= 32)
        {
            TowerHP = 120.0f;
            if (towerspawn.stage == 30 || towerspawn.stage == 35)
                TowerHP = 140.0f;
            TowerLevel = 4;
        }
        else if (towerspawn.stage <= 40)
        {
            TowerHP = 140.0f;
            if (towerspawn.stage == 30 || towerspawn.stage == 35)
                TowerHP = 160.0f;
            TowerLevel = 5;
        }
        else
        {
            TowerHP = 160.0f;
            if (towerspawn.stage == 40 || towerspawn.stage == 45 || towerspawn.stage == 50 || towerspawn.stage == 55)
                TowerHP = 180.0f;
            TowerLevel = 6;
        }

        // 레벨 에 따른 데미지 변화
        DamageByLevel();

        EffectList = GameObject.Find("EffectManager").gameObject;
    }


    void Update()
    {

        // 체력감소시스템
        // if(플레이어의 태그 = 불렛에 닿으면){TowerHP-BulletDamage)}

        //float nextTowerHP = TowerHP + 10f;
        //float nextTowerShootingSpeed = TowerShootingSpeed + 0.1f;
        //float nextTowerAttackDamage = TowerAttackDamage + 0.2f;
        //int nextTowerLevel = TowerLevel + 1;

        //AliveTowerNumber = GameObject.Find("Map Example").GetComponent<TowerSpawn>().TowerCount; // 살아있는 타워 수는 타워 넘버에서 받아옴

        if (TowerHP <= 0) //타워의 hp가 0이하라면
        {
            TowerDie(); //타워죽음 실행
        }


        // 아직 미구현
        //if (isDestroyed == true) // 타워가 파괴되었다면,
        //{
        //    TowerHP = nextTowerHP;
        //    TowerShootingSpeed = nextTowerShootingSpeed;
        //    CurrentAttackDamage = nextTowerAttackDamage;
        //    TowerLevel = nextTowerLevel; // 다음 젠부터 타워의 스탯을 다음 단계로 증가시켜라, 
        //}

        //if (isDamaged == true)
        //{
        //    //TowerHP - DamagingBullet.damage // 타워의 체력을 DamagingBullet의 damage수치만큼 깎아라
        //}



    }

    void DamageByLevel()
    {
        CurrentAttackDamage = TowerAttackDamage * (1 + 0.1f * TowerLevel);
        // 1.0 * (1 + 0.1 *TowerLevel)
        // TowerLevel : 1~ 6
        // result : 1.1 ~ 1.6
    }

    void Disabled()
    {
        EffectList.transform.GetChild(46).gameObject.SetActive(false);
    }
}
