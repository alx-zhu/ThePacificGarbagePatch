using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flappy : MonoBehaviour
{
    // Movement speed
    public float speed = 2;
    
    //Flap force
    public float force = 300;
    public Transform target;
    public GameObject resultScreen;
    public GameObject resultScreenNoPlayAgain;
    public GameObject startScreen;
    public GameObject winScreen;
    //public Image fillbar;
    public Slider progressBar;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI coinText;

    Obstacle[] obstacles;
    Rigidbody2D rb;

    bool start;
    bool lose;
    bool coinsGiven;
    bool expGiven;
    float currentCoins;
    float currentExp;
    float firstSpace; //firstSpace makes it so the first input of
                      //space only removes the intro screen and does not give any force to the bird
    float percentage;
    float maxDistance = 58;

    void Start()
    {
        //Fly towards the right
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        resultScreen.SetActive(false);
        startScreen.SetActive(true);

        obstacles = FindObjectsOfType<Obstacle>();

        firstSpace = 1;
        start = false;
        lose = false;
        coinsGiven = false;
        expGiven = false;
    }

    void StartGame() {
        if (start == false && Input.GetKey("space") && lose == false && firstSpace >= 0)
        { //must include lose == false, otherwise if(start == false && input(space)) will evaluate to true and
          //the velocity will momentarily be positive.
            rb.isKinematic = false;
            rb.velocity = Vector2.right * speed;
            startScreen.SetActive(false);
            start = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();

        if (start && firstSpace == 0)
        {
            percentage = rb.position.x / maxDistance;
            SetProgressBarLength();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (rb.velocity.magnitude <= 20)
                {
                    rb.AddForce(Vector2.up * force);
                }
            }
            if (target == null)
            {
                return;
            }
            if (target.position.x >= maxDistance)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Win();
                Stop();
                rb.isKinematic = true;
                rb.velocity = Vector2.right * 0;
            }
            else if (target.position.y >= 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (firstSpace != 0 && Input.GetKeyDown("space"))
        {
            firstSpace--;
        }
    }

    //Called when a collision occurs (Bird hits ground or obstacle)
    void OnCollisionEnter2D(Collision2D coll){
        //Restart
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        if (PlayerPrefs.GetFloat("frommainmenu") == 1) {
            resultScreenNoPlayAgain.SetActive(true);
            PlayerPrefs.SetString("dtpComplete", "dtpPartial");
            if (expGiven == false && coinsGiven == false)
            {
                currentExp = PlayerPrefs.GetFloat("exp");
                float expAward = percentage * 50;
                expAward = Mathf.RoundToInt(expAward);
                expText.text = "+" + expAward + " EXP";
                currentExp += expAward;
                PlayerPrefs.SetFloat("exp", currentExp);

                float coinAward = expAward;
                coinText.text = "+" + coinAward + " coins";
                currentCoins += coinAward;
                PlayerPrefs.SetFloat("coins", currentCoins);

                Debug.Log(expAward);
                expGiven = true;
                coinsGiven = true;
            }
            PlayerPrefs.SetFloat("frommainmenu", 0);
        }
        else
        {
            resultScreen.SetActive(true);
        }

        rb.isKinematic = true;
        rb.velocity = Vector2.right*0;
        start = false;
        lose = true;
        firstSpace = -1;
        Stop();
        
    }

    void Stop()
    {
        for (var i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Rigidbody2D>().velocity = Vector2.up * 0;
        }
    }

    public void disableSpace() {
        firstSpace = -1;
    }
    public void enableSpace() {
        firstSpace = 1;
    }

    void Win() {
        Stop();
        rb.isKinematic = true;
        rb.velocity = Vector2.right * 0;
        winScreen.SetActive(true);
        //only gives coins if the game was accessed from the main environment
        //tells the envplastic that the flappy bird game is fully played
        if (PlayerPrefs.GetFloat("frommainmenu") == 1) {
            if (coinsGiven == false)
            {
                currentCoins = PlayerPrefs.GetFloat("coins");
                currentCoins += 50;
                PlayerPrefs.SetFloat("coins", currentCoins);
                coinsGiven = true;
            }
            if (expGiven == false) {
                currentExp = PlayerPrefs.GetFloat("exp");
                currentExp += 50;
                PlayerPrefs.SetFloat("exp", currentExp);
                expGiven = true;
            }
            PlayerPrefs.SetFloat("frommainmenu", 0);
            PlayerPrefs.SetString("dtpComplete", "dtpComplete");
        }
    }

    void SetProgressBarLength()
    {
        //fillbar.GetComponent<Rigidbody2D>();
        //fillbar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, percentage * 550);
        progressBar.value = percentage;
    }
}
