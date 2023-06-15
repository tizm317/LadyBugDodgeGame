using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusic : MonoBehaviour
{
    public void DestroyTitleMusic()
    {
        Destroy(GameObject.Find("TitleMusic"));
        Destroy(GameObject.Find("ClickSound"));
        Destroy(GameObject.Find("AdMob Manager"));


    }

    public void ClickSound()
    {
        if (GameObject.Find("ClickSound"))
            GameObject.Find("ClickSound").GetComponent<AudioSource>().Play();
    }

    public void ClickSound1()
    {
        if (GameObject.Find("ClickSound1"))
            GameObject.Find("ClickSound1").GetComponent<AudioSource>().Play();
    }
}
