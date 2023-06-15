using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    GameObject player;
    public double code = 0; // 총알 속성
    public float damage = 10.0f; // (기본 총알)총알 데미지 변수
    const float Level_Zero = 10.0f; // 속성 총알 기본 데미지
    const float Level_Two = 10.0f;     // x.1 총알 데미지
    const float Level_Three = 10.0f;   // x.2 총알 데미지


    // Start is called before the first frame update
    void Start()
    {
        //player = gameObject.transform.root
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent.GetComponentInChildren<Element>())
            code = gameObject.transform.parent.GetComponentInChildren<Element>().player_element; // 부모 오브젝트의 첫번째 child 오브젝트
     
        //총알 데미지
        Damage();
    }

    void Damage()
    {
        if (code == 0 )
            damage = 10;
        else if(code == 1 || code == 2 || code == 3 || code == 4 || code == 5)
            damage = Level_Zero;
        else if (code == 1.1 || code == 2.1 || code == 3.1 || code == 4.1 || code == 5.1)
            damage = Level_Two;
        else
            damage = Level_Three;
    }
}
