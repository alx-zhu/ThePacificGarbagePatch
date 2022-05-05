using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : MonoBehaviour
{
    public GameObject popUp;
    //public bool isPoppedUp;

    public CoinCounter cc;

    public float fishCost = 100;
    public float swimSpeed = 0;
    public float switchTime;

    //to set max and min x and y positions for mouse clicks to register
    public float minMouseX = 395;
    public float maxMouseX = 717;
    public float minMouseY = 0;
    public float maxMouseY = 88;

    public GameObject notification;

    //to set random direction when enabled
    float[] directionArray = { -4, 4 };
    //to set random y position when enabled

    Rigidbody2D rb2D;
    SpriteRenderer sr;

    Vector2 direction;

    public bool selected;
    float clicks;

    Dolphin[] dolphins;

    /*void Awake()
    {
        DontDestroyOnLoad(this);
        gameObject.SetActive(true);
    }*/

    //-3 to 2.75 y
    void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        /*flipInitially = randomBool[Random.Range(0, 1)];
        sr.flipX = flipInitially;*/

        rb2D.isKinematic = true;

        swimSpeed = 3;
        gameObject.transform.localScale = new Vector3(directionArray[Random.Range(0, 2)], 5, 1);
        if (gameObject.transform.localScale.x < 0)
        {
            rb2D.velocity = Vector2.left * swimSpeed;
            rb2D.position = new Vector2(25, 3);
        }
        else
        {
            rb2D.velocity = Vector2.right * swimSpeed;
            rb2D.position = new Vector2(-25, 3);
        }


        direction = rb2D.velocity;
        direction.Normalize();

    }

    void OnMouseDown()
    {
        popUp.SetActive(true);
        notification.SetActive(false);
        sr.color = Color.yellow;
        selected = true;
        clicks = 2;
    }

    public void DestroyFish()
    {
        dolphins = FindObjectsOfType<Dolphin>();

        foreach (var i in dolphins)
        {
            if (i.selected)
            {
                Destroy(i.gameObject);
                clicks = 0;
                selected = false;
                int temp = PlayerPrefs.GetInt("nDolphin");
                temp--;
                PlayerPrefs.SetInt("nDolphin", temp);

                //give coins back
                float currentCoins = PlayerPrefs.GetFloat("coins");
                currentCoins = currentCoins + fishCost / 2;
                currentCoins = Mathf.RoundToInt(currentCoins);
                PlayerPrefs.SetFloat("coins", currentCoins);
                cc.UpdateText();
            }
        }
    }

    void Update()
    {
        if (rb2D.position.x > 25)
        {
            rb2D.velocity = Vector2.left * swimSpeed;
            gameObject.transform.localScale = new Vector3(-4, 4, 1);
        }
        if (rb2D.position.x < -25)
        {
            rb2D.velocity = Vector2.right * swimSpeed;
            gameObject.transform.localScale = new Vector3(4, 4, 1);
        }

        if (clicks > 0 && Input.GetMouseButtonDown(0))//if the mouse is inside the button, click doesnt count
        {
            if (Input.mousePosition.x < minMouseX || Input.mousePosition.x > maxMouseX || Input.mousePosition.y < minMouseY || Input.mousePosition.y > maxMouseY)
            {
                clicks--;
            }
        }

        if (selected && clicks == 0)
        {
            selected = false;
            sr.color = Color.white;
            popUp.SetActive(false);
        }

    }
}
