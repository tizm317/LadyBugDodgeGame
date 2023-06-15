using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodColor : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
    }
}
