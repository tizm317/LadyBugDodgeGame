using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnim : MonoBehaviour
{
    Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }

    public void resetAnim()
    {
        transform.position = new Vector3(0, 4.85f, 0);
        dir = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), -0.3f).normalized;
    }
}
