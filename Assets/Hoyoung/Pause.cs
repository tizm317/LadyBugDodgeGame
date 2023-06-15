using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public GameObject BackButton;
    public GameObject Continue;
    static public bool IsPause = false;

    // Use this for initialization
    void Start()
    {
        //IsPause = false;
    }

    public void Pauz()
    {
        {
            /*일시정지 활성화*/
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                BackButton.SetActive(true);
                Continue.SetActive(true);
                return;
            }

            /*일시정지 비활성화*/
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                BackButton.SetActive(false);
                Continue.SetActive(false);
                return;
            }
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        /*일시정지 활성화*/
    //        if (IsPause == false)
    //        {
    //            Time.timeScale = 0;
    //            IsPause = true;
    //            return;
    //        }

    //        /*일시정지 비활성화*/
    //        if (IsPause == true)
    //        {
    //            Time.timeScale = 1;
    //            IsPause = false;
    //            return;
    //        }
    //    }
    //}
}



//출처: https://solution94.tistory.com/20 [솔루션 개발일지]
