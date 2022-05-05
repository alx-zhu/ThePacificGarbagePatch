using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public GameObject MarineObjects;
    public GameObject CoralObjects;

    string previousScene;

    // Start is called before the first frame update
    void Start()
    {
        previousScene = PlayerPrefs.GetString("previousScene");
        if (previousScene.Equals("MarineEnvironment"))
        {
            MarineObjects.SetActive(true);
            CoralObjects.SetActive(false);
        }
        else if (previousScene.Equals("CoralEnvironment")) {
            CoralObjects.SetActive(true);
            MarineObjects.SetActive(false);
        }
    }
}
