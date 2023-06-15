using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public int count = 0;
    static public bool Easter = false;

    

    // Update is called once per frame
    void Update()
    {
        if (count == 7)
            Easter = true;
        else
            Easter = false;
    }

    public void EasterButton()
    {
        count++;
    }
}
