using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    /* LvUp Effect */
    static public GameObject EffectList;
    int i = 26; // skill level up effect : 26
    int j = 42; // player heal effect  : 42
    

    /* experience */
    //[Range(0,20)] // 의미 없어보여서 지움
    static public int experience = 0;
    static public int level = 1;

    static public int score = 0; // 나중에 그냥 experience 쓸수도 있음 / 누적 경험치 = 점수

    //타워 점수 10점 때문에 수정
    static public int exp;

    /* skill points */
    static public int skill_point = 0;

    /* skill Level */


    static public bool levelup = false;

    private void Awake()
    {
        // static 변수들은 씬 재로딩 시 초기화 x
        // awake 나 start 에서 다시 초기화
        experience = 0;
        level = 1;
        skill_point = 0;
        levelup = false;
        score = 0;
    }


    /*Lv Up Effect */
    // Start is called before the first frame update
    void Start()
    {
        EffectList = GameObject.Find("EffectManager").gameObject;
        
    }

    public void Disabled()
    {
        EffectList.transform.GetChild(i).gameObject.SetActive(false);
        EffectList.transform.GetChild(j).gameObject.SetActive(false);
    }

    void LV_UP_Effect()
    {
        //Instantiate(element, transform.position, transform.rotation);
        //Destroy(element, lifetime);

        EffectList.transform.GetChild(i).gameObject.SetActive(true);
        EffectList.transform.GetChild(i).gameObject.transform.position = transform.position;
        Invoke("Disabled", 1);
    }

    void Healing_Effect() 
    {

        EffectList.transform.GetChild(j).gameObject.SetActive(true);
        EffectList.transform.GetChild(j).gameObject.transform.position = transform.position;
        Invoke("Disabled", 1);
    }


    /* Hp */
    // 문제 발생! 경험치 코드에서 모든 캐릭터의 경험치랑 Hp 를 관리 하다보니 하나의 통합된 경험치와 Hp 를 공유하는듯.. 아마 static 영향인지도
    //static public int Hp = 10;


    // OnTriggerEnter2D(Collider2D ) 이거 썼었는데 Hp 가 두배로 줄어서 뭐가 문제지 하고 찾아보니 이거는 통과할 때 사용하는 거고 + IsTrigger 둘다 켜져있어야함
    // Collision 을 쓰면 충돌 하는 경우임 + IsTrigger 둘다 꺼져 있어야 하고


    /* 문제 해결 */
    // 체력이 내가 발사할 때도 달음...;;; -> Layer 설정으로 막음

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Food")
        {
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false); //비활성화
            //Debug.Log("ExperienceUp!!");
            experience++;
            score++;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
        
    }

  

    void Heal()
    {
        GameObject.Find("Character").GetComponent<Hp>().hp  = 10;
        Healing_Effect();
      
    }

    void ResetCool()
    {
        GameObject.Find("Character").GetComponent<Player_Fire>().CoolTime = 15.0f;
    }

    int pointValue = 1;

    int SkillPointUp()
    {
        // level 10 증가 시 마다 skill point 2 증가

        if (level % 10 == 0)
            pointValue = 2;
        else
            pointValue = 1;

        return pointValue;
    }

    void LevelUp()
    {
        if (level < 100) // 최고 레벨 100
        {
            if (experience >= 10 * level)
            //if (experience == 2) // 1렙(2렙까지 필요 경험치 : 10 ) 2렙(3렙까지 필요 경험치 : 20) 
            {
                level++;
                Heal();
                ResetCool();
                exp = experience; //타워 점수 10점 때문에 수정
                //experience -= 10 * level; // 필요한가? 중복인거 같아서 지움
                //skill_point++;
                skill_point += SkillPointUp(); // 수정
                LV_UP_Effect();
                levelup = true;
            }
        }
    }
    
}
