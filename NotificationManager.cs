using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    public GameObject notification;
    public TextMeshProUGUI notificationText;

    Vector2 notifpos;

    string[] randomFact = { "Did you know? You can click on the fish to sell them or to view their journal pages! Try it out!",
        "Did you know that there are over 3.2 BILLION people who live in areas with very high water scarcity? That's 2/5ths of the world's population!",
        "The side menu gives you access to the fish shop, data input, the minigames, the fish journal, and your profile.",
        "Guess what! You can unlock a NEW marine environment by leveling up! Click the second button on the menu to view and visit these environments!",
        "Did you know? The average person uses 80 to 100 gallons of water each day. That is A LOT of water :(",
        "The Pacific Garbage Patch is a collection of garbage, plastic, and chemicals in the Pacific Ocean that is more than 2x bigger than Texas!",
        "Click on the plastic in your marine environment to play minigames and earn exp and coins!"};
    
    void Start()
    {
        RandomNotification();
        notification.GetComponent<Rigidbody2D>().position = new Vector2(0, -270);
    }

    void RandomNotification()
    {
        notification.SetActive(true);
        notificationText.text = randomFact[Random.Range(0, randomFact.Length)];
        StartCoroutine(MoveNotification());
    }

    IEnumerator MoveNotification()
    {
        yield return new WaitForSeconds(1 / 1000);
        notifpos = notification.GetComponent<Rigidbody2D>().position;
        if (notifpos.y < -4.45f)
        {
            notification.GetComponent<Rigidbody2D>().position = new Vector2(notifpos.x, notifpos.y + 0.05f);
            StartCoroutine(MoveNotification());
        }
    }

    /*void OnEnable()
    {
        Debug.Log(notification.GetComponent<Rigidbody2D>().position.y);
    }*/
}
