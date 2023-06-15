using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (EasterEgg.Easter == true)
            Experience.skill_point = 999;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
