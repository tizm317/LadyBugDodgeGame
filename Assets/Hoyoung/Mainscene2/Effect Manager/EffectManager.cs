using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectManager : MonoBehaviour
{
    /* 이펙트 종류 관리 */
    // 아래쪽에 종류 적어둠

    public static EffectManager instance;
    
    public GameObject[] EffectPrefab;
    public static int EffectCount = 47; // 수 바뀌면 꼭 수정

    //public int arraySize;


    List<GameObject> effects = new List<GameObject>(); // food 을 담아둘 리스트 만듬

    private void Awake()
    {
        if (EffectManager.instance == null)
        {
            EffectManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //arraySize = 16;
        //EffectPrefab = new GameObject[arraySize];
        CreateEffects(EffectCount); // food 5개 생성
    }

    void CreateEffects(int effectCount)
    {

        for (int i = 0; i < effectCount; i++)
        {
            //EffectPrefab[i].gameObject.AddComponent<EffectLifeTime>(); // 영구적으로 생김;;;

            //Instantiate() 로 생성한 게임 오브젝트를 변수에 담고자 하면, "as + 데이터타입" 을 명령어 뒤에 붙여야함
            GameObject effect = Instantiate(EffectPrefab[i]) as GameObject;

            effect.transform.parent = transform;
            effect.SetActive(false);

            effects.Add(effect);
        }
        for(int j = 0; j < 4; j++)
        {
            GameObject effect = Instantiate(EffectPrefab[24]) as GameObject;
            effect.transform.parent = transform;
            effect.SetActive(false);

            effects.Add(effect);
        }
        
    }

    

    public GameObject GetEffect(Vector2 pos)
    {
        GameObject reqEffect = null;
        for (int i = 0; i < effects.Count; i++)
        {
            if (effects[i].activeSelf == false)
            {
                reqEffect = effects[i]; //비활성화 되어있는 food 을 찾아 reqFood 에 담아둡니다

                break;
            }
        }

        if (reqEffect == null)//추가 food 생성
        {
            GameObject newEffect = Instantiate(EffectPrefab[1]) as GameObject;
            newEffect.transform.parent = transform;

            effects.Add(newEffect);
            reqEffect = newEffect;
        }

        reqEffect.SetActive(true); //reqFood활성

        reqEffect.transform.position = pos;

        return reqEffect;
    }

    

    //EffectCount = 42 ( 0~ 41)
    //Element0 기본공격
    //Element1,2,3 화속성 1,2,3
    //Element4,5,6,수속성 1,2,3
    //Element7,8,9 목속성 1,2,3
    //Element10,11,12 금속성 1,2,3
    //Element13,14,15 토속성 1,2,3
    //Element 16 음양 속성
    //Element 17 공란 18번 공란
    //19-23 화수목금토 속성구슬 획득 이펙트, 
    //24 경험치 획득
    //25 스킬 레벨업 26플레이어 레벨업
    //27,28,29,30,31 각각 궁 이펙트
    //32,33,34,35,36 각각 버릴 때 이펙트
    //37 화로 속성 변경시  이펙트
    //38 수로 속성 변경시  이펙트
    //39 목으로 속성 변경시  이펙트
    //40 금으로 속성 변경시  이펙트
    //41 토 로 속성 변경시  이펙트
    //EffectManager.EffectCount ~ EffectManager.EffectCount+3 : 경험치 획득


}
