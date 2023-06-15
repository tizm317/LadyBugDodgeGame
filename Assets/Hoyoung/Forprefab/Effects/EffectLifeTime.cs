using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLifeTime : MonoBehaviour
{
    /* 총알 여러번 맞을 시 이펙트가 비활성화가 안되는 경우가 있어서 
     * 쿨타임 1초 만들어서  자동 비활성화 */

    float Cooltime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Cooltime >= 1)
            Disabled();

        Cooltime += Time.deltaTime;
    }

    void Disabled()
    {
        this.gameObject.SetActive(false);
        Cooltime = 0f;
        //Debug.Log("쿨타임 지나서 비활성화");
    }

    private void OnDisable()
    {
        Cooltime = 0f;
        //Debug.Log("비활성화 되면서 쿨타임 초기화");
    }
}
