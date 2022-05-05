using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public ParticleSystem pSystem;

    //bool broken;
    float collisions = 2;

    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rb.isKinematic = true;

        collisions = 2;
        //broken = false;

        sr.color = new Color(1, 1, 1, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ScubaDiver scuba = collision.gameObject.GetComponent<ScubaDiver>();
        if (scuba != null)
        {
            pSystem.Play();
            collisions--;
            sr.color = new Color(1, 1, 1, 0.5f);
        }
        if (collisions == 0)
        {
            pSystem.Play();
            gameObject.SetActive(false);
        }
    }

    /*bool ShouldBreakFromCollision(Collision2D collision)
    {
        if (broken) {
            return false;
        }
    }*/
}
