using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Pause.IsPause == true)
        {
            Time.timeScale = 1;
            Pause.IsPause = false;
            return;
        }
    }

}
