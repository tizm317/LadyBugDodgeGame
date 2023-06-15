using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_code : MonoBehaviour
{
    public int element_code = 0; // 기본 속성 '0' 제외, 총 5개 속성 (1,5)
    int random;

    private void OnEnable()
    {
            // 자연 생성되는 구슬
            random = Random.Range(1, 6); // 주의
            element_code = random;
    }
}

