using System.Collections;
using UnityEngine;

public class TutorialFish : MonoBehaviour
{
    public float swimSpeed = 0;

    public float switchTime;

    bool[] randomBool = { true, false };

    float[] timeArray = { 0.5f, 1, 1.5f, 2, 2.5f, 3, 3.5f, 4, 4.5f, 5, 00 };

    float[] speedArray = { 0.5f, 0.75f, 1, 1.25f, 1.5f, 1.75f };

    float[] directionArray = { -1, 1 };

    Rigidbody2D rb2D;

    SpriteRenderer sr;

    Vector2 direction;

    void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        /*flipInitially = randomBool[Random.Range(0, 1)];
        sr.flipX = flipInitially;*/

        rb2D.isKinematic = true;

        swimSpeed = 1;
        gameObject.transform.localScale = new Vector3(directionArray[Random.Range(0, 2)], 1, 1);
        if (gameObject.transform.localScale.x > 0)
        {
            rb2D.velocity = Vector2.left * swimSpeed;
        }
        else
        {
            rb2D.velocity = Vector2.right * swimSpeed;
        }


        direction = rb2D.velocity;
        direction.Normalize();

        switchTime = timeArray[Random.Range(0, 10)];

        //InvokeRepeating("SwitchDirection", switchTime, Random.Range(1,7));
        //InvokeRepeating("ChangeSpeed", switchTime, switchTime);
        StartCoroutine(SwitchDirection());
        //StartCoroutine(ChangeSpeed());
    }

    IEnumerator SwitchDirection()
    {
        //yield return new WaitForSeconds(switchTime);

        if ((rb2D.position.x > 7 && direction.x > 0) || (rb2D.position.x < -9 && direction.x < 0))
        {
            switchTime = 7;
            if (rb2D.position.x > 7)
            {
                rb2D.velocity = Vector2.left * swimSpeed;
                Debug.Log("Too Far Right");
                direction = rb2D.velocity;
                direction.Normalize();
                yield return new WaitForSeconds(7);
                StartCoroutine(SwitchDirection());
            }
            else if (rb2D.position.x < -9)
            {
                rb2D.velocity = Vector2.right * swimSpeed;
                Debug.Log("Too Far Left");
                direction = rb2D.velocity;
                direction.Normalize();
                yield return new WaitForSeconds(7);
                StartCoroutine(SwitchDirection());
            }

        }
        else
        {
            switchTime = timeArray[Random.Range(0, 10)];
            rb2D.velocity *= -1;
            direction = rb2D.velocity;
            direction.Normalize();
            yield return new WaitForSeconds(switchTime);
            StartCoroutine(SwitchDirection());
        }
    }

    /*IEnumerator ChangeSpeed()
    {
        yield return new WaitForSeconds(switchTime);

        if (switchTime < 2) {
            swimSpeed = speedArray[Random.Range(0, 5)];
        } else
        {
            swimSpeed = speedArray[Random.Range(0, 2)];
        }

        StartCoroutine(ChangeSpeed());
    }*/

    // Update is called once per frame
    void Update()
    {
        if (direction.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

