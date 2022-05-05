using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButterflyFish : MonoBehaviour
{
    public GameObject popUp;
    //public bool isPoppedUp;

    public CoinCounter cc;

    public float fishCost = 25;
    public float swimSpeed = 0;
    public float switchTime;

    //for random sprites
    public Sprite sprite1;
    public Sprite sprite2;

    //to set max and min x and y positions for mouse clicks to register
    public float minMouseX = 395;
    public float maxMouseX = 717;
    public float minMouseY = 0;
    public float maxMouseY = 88;

    public GameObject notification;

    //to set random times for fish to turn
    float[] timeArray = { 0.5f, 1, 1.5f, 2, 2.5f, 3, 3.5f, 4, 4.5f, 5, 00 };
    //to set random direction when enabled
    float[] directionArray = { -1, 1 };
    //to set random y position when enabled
    float[] randomYpos = { -3, -2.75f, -2.5f, -2.25f, -2, -1.75f, -1.5f, -1.25f, -1, -0.75f, -0.5f, -0.25f, 0,
                            0.25f, 0.5f, 0.75f, 1, 1.25f, 1.5f, 1.75f, 2, 2.25f, 2.5f, 2.75f, 3};

    Rigidbody2D rb2D;
    SpriteRenderer sr;

    Vector2 direction;

    public bool selected;
    float clicks;

    float randomX;
    float randomY;

    //Change this for each fish
    ButterflyFish[] butterflyFish;

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

        int caseSwitch = Random.Range(1, 3);
        switch (caseSwitch)
        {
            case 1:
                sr.sprite = sprite1;
                break;
            case 2:
                sr.sprite = sprite2;
                break;
            default:
                sr.sprite = sprite1;
                break;
        }

        /*flipInitially = randomBool[Random.Range(0, 1)];
        sr.flipX = flipInitially;*/

        //choose random x and y position (using multiples of 10 so there can be decimal values)
        rb2D.isKinematic = true;
        randomX = Random.Range(-8.5f, 7f);
        randomY = Random.Range(-3f, 3f);
        rb2D.position = new Vector2(randomX, randomY);

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

        switchTime = timeArray[Random.Range(0, timeArray.Length)];

        StartCoroutine(SwitchDirection());

    }

    IEnumerator SwitchDirection()
    {
        //yield return new WaitForSeconds(switchTime);

        if ((rb2D.position.x > 9 && direction.x > 0) || (rb2D.position.x < -9 && direction.x < 0))
        {
            switchTime = 7;
            if (rb2D.position.x > 9)
            {
                rb2D.velocity = Vector2.left * swimSpeed;
                direction = rb2D.velocity;
                direction.Normalize();
                yield return new WaitForSeconds(7);
                StartCoroutine(SwitchDirection());
            }
            else if (rb2D.position.x < -9)
            {
                rb2D.velocity = Vector2.right * swimSpeed;
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

    void OnMouseDown()
    {
        popUp.SetActive(true);
        notification.SetActive(false);
        sr.color = Color.gray;
        selected = true;
        clicks = 2;
    }

    public void DestroyFish()
    {
        butterflyFish = FindObjectsOfType<ButterflyFish>();

        foreach (var i in butterflyFish)
        {
            if (i.selected)
            {
                Destroy(i.gameObject);
                clicks = 0;
                selected = false;
                Debug.Log("Destroyed");
                if (SceneManager.GetActiveScene().name.Equals("CoralEnvironment"))
                {
                    int temp3 = PlayerPrefs.GetInt("nButterflyFish");
                    temp3--;
                    PlayerPrefs.SetInt("nButterflyFish", temp3);

                    int temp4 = PlayerPrefs.GetInt("totalCoralFish");
                    temp4--;
                    PlayerPrefs.SetInt("totalCoralFish", temp4);
                }

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
        if (direction.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (clicks > 0 && Input.GetMouseButtonDown(0))//if the mouse is inside the button, click doesnt count
        {
            if (Input.mousePosition.x < minMouseX || Input.mousePosition.x > maxMouseX || Input.mousePosition.y < minMouseY)
            {
                clicks--;
            }
        }

        //for testing click locations
        /*if (Input.GetMouseButtonDown(0)) {
            Debug.Log(Input.mousePosition.x + " " + Input.mousePosition.y);
        }*/

        if (selected && clicks == 0)
        {
            selected = false;
            sr.color = Color.white;
            popUp.SetActive(false);
        }

    }
}
