using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Drop : MonoBehaviour
{
    //public GameObject Food;
    public GameObject Element;
    //float spawn_time = 0.5f;
    //int count = 0;
    //private float lifeTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawnfood", 1, 1); // InvokeRepeating("함수", 처음 딜레이, 그 이후 몇초마다)
        InvokeRepeating("Spawnitem", 1, 1); // 생성 속도 조절(마지막 숫자)

    }

    void Spawnfood()
    {
        float randomX = 10;
        float randomY = 10;

        while (!((2*randomY-randomX) > -12 && (2 * randomY - randomX) < 12 && (2 * randomY + randomX) > -12 && (2 * randomY + randomX) < 12))
        {
            randomX = Random.Range(-10f, 10f); // 0.8f 가 x축 중간 
            randomY = Random.Range(-6f, 6f); // 0.5f 가 y축 중간


            //randomX = Random.Range(-6f, 6f); // 0.8f 가 x축 중간 
            //randomY = Random.Range(-3f, 3f); // 0.5f 가 y축 중간
        }


        if (true)
        {
            //Debug.Log("생성");
            ObjectManager.instance.GetFood(new Vector2(randomX, randomY));
            //GameObject food = (GameObject)Instantiate(Food, new Vector2(randomX, randomY), Quaternion.identity);
        }
    }

    void Spawnitem()
    {
        float randomX = 10;
        float randomY = 10;

        while (!((2 * randomY - randomX) > -10 && (2 * randomY - randomX) < 10 && (2 * randomY + randomX) > -10 && (2 * randomY + randomX) < 10))
        {
            randomX = Random.Range(-10f, 10f); // 0.8f 가 x축 중간 
            randomY = Random.Range(-6f, 6f); // 0.5f 가 y축 중간


            //randomX = Random.Range(-6f, 6f); // 0.8f 가 x축 중간 
            //randomY = Random.Range(-3f, 3f); // 0.5f 가 y축 중간
        }
        if (true)
        {
            //Debug.Log("생성");
            ObjectManager.instance.GetElement(new Vector2(randomX, randomY));
            //GameObject food = (GameObject)Instantiate(Element, new Vector2(randomX, randomY), Quaternion.identity);
        }
    }

}
