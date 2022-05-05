using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 0;
    
    public float switchTime = 2;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Initial Moveement Direction
        GetComponent<Rigidbody2D>().velocity = Vector2.up*speed;

        rb = GetComponent<Rigidbody2D>();

        //Switch every few seconds
        InvokeRepeating("Switch", 0, switchTime);
    }

    // Update is called once per frame
    void Switch() {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }
    
}
