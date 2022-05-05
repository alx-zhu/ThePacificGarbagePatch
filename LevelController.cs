using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject pauseButton;

    //public CoinCounter cc;

    TrappedFish[] trappedFish;
    bool coinsGiven;
    bool expGiven;
    bool alreadyComplete;
    float coinCount;
    float exp;

    float completedLevel;

    // Start is called before the first frame update
    void OnEnable()
    {
        trappedFish = FindObjectsOfType<TrappedFish>();
        /*if (nextLevelName.Equals("None"))
        {
            winScreen.SetActive(false);
        }
        else {
            winScreen = null;
        }*/
        winScreen.SetActive(false);
        pauseButton.SetActive(true);
        coinsGiven = false;

        alreadyComplete = false;

        completedLevel = PlayerPrefs.GetFloat("completedlevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (FishAllSaved()) {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        if (PlayerPrefs.GetFloat("frommainmenu") == 1)
        {
            float previouslevel = PlayerPrefs.GetFloat("completedlevel");
            float currentlevel = previouslevel + 1;
            winScreen.SetActive(true);
            pauseButton.SetActive(false);
            //cc.addCoins(50);
            if (!coinsGiven)
            {
                coinCount = PlayerPrefs.GetFloat("coins");
                coinCount += 50;
                PlayerPrefs.SetFloat("coins", coinCount);
                coinsGiven = true;

                alreadyComplete = true;

                if (currentlevel < 4)
                {
                    //sets the currently completed level so when the plastic is clicked again, it will go to the next level.
                    PlayerPrefs.SetFloat("completedlevel", currentlevel);
                    PlayerPrefs.SetString("stfComplete", "stfComplete");
                }
                else
                {
                    PlayerPrefs.SetFloat("completedlevel", 0);
                    PlayerPrefs.SetString("stfComplete", "stfComplete");
                }
                PlayerPrefs.SetFloat("frommainmenu", 0);
            }
        }
        else if (!alreadyComplete){
            if (nextLevelName.Equals("None"))
            {
                winScreen.SetActive(true);
                if (!coinsGiven)
                {
                    coinCount = PlayerPrefs.GetFloat("coins");
                    coinCount += 50;
                    PlayerPrefs.SetFloat("coins", coinCount);
                    coinsGiven = true;
                }
                if (!expGiven) {
                    exp = PlayerPrefs.GetFloat("exp");
                    exp += 50;
                    PlayerPrefs.SetFloat("exp", exp);
                    expGiven = true;
                }
            }
            else
            {
                Debug.Log("Go to level " + nextLevelName);
                SceneManager.LoadScene(nextLevelName);
            }
        }
        //must go to File -> Build Settings --> Scenes in Build to add the scenes.
        //Then, press File -> Save Project to save the settings
    }

    public void ResetCompleted()
    {
        PlayerPrefs.SetFloat("completedlevel", 0);
    }

    bool FishAllSaved(){
        foreach (var tfish in trappedFish) {
            if (tfish.gameObject.activeSelf) {
                return false;
            }
        }
        return true;
    }
}
