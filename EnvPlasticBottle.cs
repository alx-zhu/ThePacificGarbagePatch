using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvPlasticBottle : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    bool disabled;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < -10)
        {
            rb.position = new Vector2(10, rb.position.y);
        }
        else if (rb.position.x > 10)
        {
            rb.position = new Vector2(-10, rb.position.y);
        }
    }


    void OnMouseOver()
    {
        sr.color = new Color(1, 1, 1, 0.5f);
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("DodgeThePlastic");
            //tells the program if the click is coming from the main menu or from the minigames menu (1 means from main menu)
            PlayerPrefs.SetFloat("frommainmenu", 1);
        }
    }

    void OnMouseExit()
    {
        sr.color = new Color(1, 1, 1, 0.75f);
    }
}
