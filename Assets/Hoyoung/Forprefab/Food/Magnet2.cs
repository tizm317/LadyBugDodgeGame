using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet2 : MonoBehaviour
{
    public GameObject magnetic;

    // Start is called before the first frame update
    void Start()
    {
        magnetic = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        RandomBox rb = GameObject.Find("Button").GetComponent<RandomBox>();

        if(rb.magnetPlay)
        {
            // 자석의 거리를 재는 코드
            float distance = Vector2.Distance(magnetic.transform.position, transform.position);

            // 방향
            Vector3 directionToMagnet = magnetic.transform.position - transform.position;

            // 거리별 속도
            if (distance <= 0.5f)
            {
                transform.position = magnetic.transform.position;
            }
            else if (distance <= 1.0f)
            {
                transform.Translate(directionToMagnet * 5f * Time.deltaTime);

            }
            else if (distance <= 1.5f)
            {

                transform.Translate(directionToMagnet * 3f * Time.deltaTime);

            }
            else if (distance <= 2.0f)
            {
                transform.Translate(directionToMagnet * 2.5f * Time.deltaTime);

            }
            else if (distance <= 3.0f)
            {
                transform.Translate(directionToMagnet * 2 * Time.deltaTime);

            }
        }
        
       
    }
}
