using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name != "ClickSound")
            if (SceneManager.GetActiveScene().name == "Main")
                Destroy(this.gameObject);
        else if(this.gameObject.name != "ClickSound1")
                if(SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "HowToPlay" && SceneManager.GetActiveScene().name != "Credit")
                    Destroy(GameObject.Find("ClickSound1"));

    }
        
}
