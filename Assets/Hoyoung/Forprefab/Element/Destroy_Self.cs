using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Self : MonoBehaviour
{
    public float lifeTime = 5.0f;
    float _time = 0;
    

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
        if (_time >= lifeTime)
        {
            this.gameObject.SetActive(false);
            _time = 0;
        }
    }

}
