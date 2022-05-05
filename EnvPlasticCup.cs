using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvPlasticCup : MonoBehaviour
{
    public bool tutorial;

    public float completedLevel;

    Rigidbody2D rb;
    SpriteRenderer sr;

    bool disabled;

    void OnEnable()
    { 
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        completedLevel = PlayerPrefs.GetFloat("completedlevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < -10)
        {
            rb.position = new Vector2(10, rb.position.y);
        }
        else if (rb.position.x > 10) {
            rb.position = new Vector2(-10, rb.position.y);
        }

        if (rb.position.y < -5) {
            rb.position = new Vector3(Random.Range(-5f, 5f), 6f, -2);
        }

    }


    void OnMouseOver()
    {
        sr.color = new Color(1, 1, 1, 0.75f);
        //Debug.Log("entered");
        if (tutorial == false && Input.GetMouseButtonDown(0))
        {
            float nextLevel = completedLevel + 1;
            SceneManager.LoadScene("Level" + nextLevel);
            Debug.Log("Level" + completedLevel + " was last completed");
            //tells the program if the click is coming from the main menu or from the minigames menu (1 means from main menu)
            PlayerPrefs.SetFloat("frommainmenu", 1);
        }
        /*else if (tutorial == false && Input.GetMouseButtonDown(0) && levelType.Equals("dodgetheplastic"))
        {
            SceneManager.LoadScene("DodgeThePlastic");
            PlayerPrefs.SetFloat("frommainmenu", 1);
        }*/
    }

    void OnMouseExit()
    {
        sr.color = new Color(1, 1, 1, 1);
    }
}
