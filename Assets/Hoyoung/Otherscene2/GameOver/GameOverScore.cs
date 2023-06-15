using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            this.gameObject.GetComponent<Text>().text = "" + Experience.score;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
