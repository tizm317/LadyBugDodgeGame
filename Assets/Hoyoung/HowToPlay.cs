using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlay : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextbutton()
    {
        int n = this.gameObject.transform.GetSiblingIndex();
        int m = this.gameObject.transform.parent.GetSiblingIndex();

        if(m == 2)
        {
            if (n != 6)
                this.gameObject.transform.parent.GetChild(n + 1).gameObject.SetActive(true);
            else
            {
                this.gameObject.transform.parent.parent.GetChild(m + 1).gameObject.SetActive(true);
                this.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
        else if(m == 3)
        {
            if (n != 8)
                this.gameObject.transform.parent.GetChild(n + 1).gameObject.SetActive(true);
            //else
            //{
            //    this.gameObject.transform.parent.parent.GetChild(m + 1).gameObject.SetActive(true);
            //    this.gameObject.transform.parent.gameObject.SetActive(false);
            //}
        }
        else
        {
            if (n != 4)
                this.gameObject.transform.parent.GetChild(n + 1).gameObject.SetActive(true);
            else
            {
                this.gameObject.transform.parent.parent.GetChild(m + 1).gameObject.SetActive(true);
                this.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
        
    }
}
