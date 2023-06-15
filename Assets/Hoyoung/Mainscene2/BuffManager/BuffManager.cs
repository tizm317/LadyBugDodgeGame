using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    static public GameObject EffectList;
    int i = 43; // 상생일때 타워에 적용되는 버프 이펙트 43
    //int j = 44; // 상극일때 타워에 적용되는 디버프 이펙트 44


    // Start is called before the first frame update
    void Start()
    {
        EffectList = GameObject.Find("EffectManager").gameObject;
    }

   public void BuffEffect(Transform tr)
    {
        i = 43;
        EffectList.transform.GetChild(i).gameObject.SetActive(true);
        EffectList.transform.GetChild(i).gameObject.transform.position = tr.position;
        Invoke("Disabled", 1);
    }
    public void DebuffEffect(Transform tr)
    {
        i = 44;
        EffectList.transform.GetChild(i).gameObject.SetActive(true);
        EffectList.transform.GetChild(i).gameObject.transform.position = tr.position;
        Invoke("Disabled", 1);
    }

    void Disabled()
    {
        EffectList.transform.GetChild(i).gameObject.SetActive(false);
    }
}
