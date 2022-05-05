using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Bottle: MonoBehaviour
{
    public Rigidbody2D target;
    public float maxY;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Bottle[] bottles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bottles = FindObjectsOfType<Bottle>();
        foreach (var b in bottles) {
            b.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        sr.color = new Color(1, 1, 1, 1);
        //rb.isKinematic = true
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(rb.position, target.position) < 3f){
            /*foreach (var b in bottles) {
                b.GetComponent<Rigidbody2D>().isKinematic = false;
            }*/
            rb.isKinematic = false;
            sr.color = new Color(0.9f, 0.9f, 1, 0.7f);
        }
        if (rb.position.y > maxY)
        {
            StartCoroutine("SetInactive");
        }
    }

    IEnumerator SetInactive() {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        rb.isKinematic = false;
    }*/
}
