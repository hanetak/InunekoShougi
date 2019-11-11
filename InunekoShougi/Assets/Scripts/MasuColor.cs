using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.6f;
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
