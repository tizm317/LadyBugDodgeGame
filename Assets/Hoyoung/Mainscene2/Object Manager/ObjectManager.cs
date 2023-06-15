using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;

    public GameObject FoodPrefab;
    public GameObject ElementPrefab;

    List<GameObject> foods = new List<GameObject>(); // food 을 담아둘 리스트 만듬
    List<GameObject> elements = new List<GameObject>(); // element 을 담아둘 리스트 만듬

    private void Awake()
    {
        if(ObjectManager.instance == null)
        {
            ObjectManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateFoods(5); // food 5개 생성
        CreateElements(5);
    }

    void CreateFoods(int foodCount)
    {
        for(int i=0; i<foodCount; i++)
        {
            //Instantiate() 로 생성한 게임 오브젝트를 변수에 담고자 하면, "as + 데이터타입" 을 명령어 뒤에 붙여야함
            GameObject food = Instantiate(FoodPrefab) as GameObject;

            food.transform.parent = transform;
            food.SetActive(false);

            foods.Add(food);
        }
    }

    void CreateElements(int elementCount)
    {
        for (int i = 0; i < elementCount; i++)
        {
            //Instantiate() 로 생성한 게임 오브젝트를 변수에 담고자 하면, "as + 데이터타입" 을 명령어 뒤에 붙여야함
            GameObject element = Instantiate(ElementPrefab) as GameObject;

            element.transform.parent = transform;
            element.SetActive(false);

            elements.Add(element);
        }
    }

    public GameObject GetFood(Vector2 pos)
    {
        GameObject reqFood = null;
        for(int i =0; i<foods.Count;i++)
        {
            if(foods[i].activeSelf == false)
            {
                reqFood = foods[i]; //비활성화 되어있는 food 을 찾아 reqFood 에 담아둡니다

                break;
            }
        }

        if(reqFood == null)//추가 food 생성
        {
            GameObject newFood = Instantiate(FoodPrefab) as GameObject;
            newFood.transform.parent = transform;

            foods.Add(newFood);
            reqFood = newFood;
        }

        reqFood.SetActive(true); //reqFood활성

        reqFood.transform.position = pos;

        return reqFood;
    }

    public GameObject GetElement(Vector2 pos)
    {
        GameObject reqElement = null;
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].activeSelf == false)
            {
                reqElement = elements[i]; //비활성화 되어있는 food 을 찾아 reqFood 에 담아둡니다

                break;
            }
        }

        if (reqElement == null)//추가 food 생성
        {
            GameObject newElement = Instantiate(ElementPrefab) as GameObject;
            newElement.transform.parent = transform;

            elements.Add(newElement);
            reqElement = newElement;
        }

        reqElement.SetActive(true); //reqFood활성

        reqElement.transform.position = pos;

        return reqElement;
    }
    
}
