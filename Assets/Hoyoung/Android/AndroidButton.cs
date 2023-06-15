using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidButton : MonoBehaviour
{
    //AdMobManager adMobManager;

    int ClickCount = 0;

    //private void Start()
    //{
    //    //adMobManager = GameObject.Find("AdMob Manager").GetComponent<AdMobManager>();
    //}

    void Update()
    {
        /* press to start 
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);
            //adMobManager.ShowFrontAd();

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }

    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

}


// Update is called once per frame
//void Update()
//    {
//        if (Application.platform == RuntimePlatform.Android)
//        {
//            if (Input.GetKey(KeyCode.Home))
//            {
//                //home button
//            }
//            else if (Input.GetKey(KeyCode.Escape))
//            {
//                //back button
//                Application.Quit();
//            }
//            else if (Input.GetKey(KeyCode.Menu))
//            {
//                //menu button
//            }
//        }
//    }

    //출처: https://202psj.tistory.com/1325 [알레폰드의 IT 이모저모]
//}
