using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] masuF;
    public int masuIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleMasu(int shouMasu)
    {
        spriteRenderer.sprite = masuF[masuIndex];
    }
}
