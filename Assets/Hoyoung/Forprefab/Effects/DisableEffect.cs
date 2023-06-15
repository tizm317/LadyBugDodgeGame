using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEffect : MonoBehaviour
{
    private float lifeTime = 1.0f;
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
