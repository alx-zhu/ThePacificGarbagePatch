using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaDiver : MonoBehaviour
{
    [SerializeField] float maxLaunchForce = 1000;
    [SerializeField] float maxDistance = 5;
    [SerializeField] ParticleSystem pSystem;
    [SerializeField] bool boost = false;
    [SerializeField] float boostPower = 500;
    [SerializeField] String diverColor = null;
    [SerializeField] GameObject pauseScreenObjects;
    [SerializeField] float maxX;

    bool paused;
    float boostsLeft = 1;
    Vector2 startPosition;
    Rigidbody2D rb2D;
    SpriteRenderer sr;
    float hit = 3;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        startPosition = rb2D.position;
        rb2D.isKinematic = true;
        if (diverColor.Equals("green"))
        {
            boost = true;
            sr.color = Color.green;
        }
        else
        {
            boost = false;
            sr.color = Color.red;
        }

    }

    /*void OnMouseDown(){
        Vector2 currentPosition = rb2D.position;
        float distance = Vector2.Distance(currentPosition, startPosition);
        float notRed = 1 - (distance/maxDistance);
        sr.color = new Color(1,notRed,notRed, 1);
    }*/

    void OnMouseUp()
    {
        if (!paused)
        {
            Vector2 currentPosition = rb2D.position;
            Vector2 direction = startPosition - currentPosition;
            direction.Normalize();

            float distance = Vector2.Distance(currentPosition, startPosition);
            float launchForce = (distance / maxDistance) * maxLaunchForce;

            rb2D.isKinematic = false;
            rb2D.AddForce(direction * launchForce);
            if (diverColor.Equals("green"))
            {
                sr.color = Color.green;
            }
            else
            {
                sr.color = Color.red;
            }

            hit = 3;
        }
    }

    void OnMouseDrag()
    {
        if (!paused)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 desiredPosition = mousePosition;

            float distance = Vector2.Distance(desiredPosition, startPosition);

            if (distance > maxDistance)
            {
                //gives direction from start position to desired position
                Vector2 direction = desiredPosition - startPosition;
                direction.Normalize();
                //desiredPosition can only be maxDistance away from the startPosition
                desiredPosition = startPosition + (direction * maxDistance);
            }

            if (desiredPosition.x > startPosition.x)
            {
                desiredPosition.x = startPosition.x;
            }

            float c = 1 - (distance / maxDistance);
            if (diverColor.Equals("red"))
            {
                //1 is red, 2 is green.
                sr.color = new Color(1, c, c);
            }
            else if (diverColor.Equals("green"))
            {
                sr.color = new Color(c, 1, c);
            }
            rb2D.position = desiredPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && boost == true && boostsLeft > 0 && rb2D.isKinematic == false)
        {
            GiveBoost();
            Debug.Log("Boost given");
            sr.color = new Color(0, 1, 0);
            boostsLeft--;
        }

        if (pauseScreenObjects.activeSelf == true)
        {
            paused = true;
        }
        else
        {
            paused = false;
        }

        if (rb2D.position.x > maxX)
        {
            Reset();
        }
    }

    void GiveBoost()
    {
        Vector2 direction = rb2D.velocity;
        direction.Normalize();
        rb2D.AddForce(direction * boostPower);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Bottle bottle = collision.gameObject.GetComponent<Bottle>();
        TrappedFish tFish = collision.gameObject.GetComponent<TrappedFish>();
        if (bottle != null || tFish != null)
        {
            if (rb2D.isKinematic == false)
            {
                StartCoroutine(ResetAfterDelay());
                if (hit > 0)
                {
                    pSystem.Play();
                }
                hit--;
            }
        }
    }

    void Reset()
    {
        rb2D.position = startPosition;
        rb2D.isKinematic = true;
        rb2D.velocity = Vector2.zero;
        boostsLeft = 1;
        sr.color = Color.white;
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        rb2D.position = startPosition;
        rb2D.isKinematic = true;
        rb2D.velocity = Vector2.zero;
        rb2D.angularVelocity = 0;
        rb2D.rotation = 0;
        boostsLeft = 1;
        sr.color = Color.white;
        if (diverColor.Equals("green"))
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.red;
        }
    }
}
