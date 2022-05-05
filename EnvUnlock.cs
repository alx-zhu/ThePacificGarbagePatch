using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnvUnlock : MonoBehaviour
{
    public GameObject lockScreenCoral;
    public GameObject unlockCoralButton;
    public GameObject visitCoralReefButton;
    public GameObject visitMarineEnvironmentButton;

    public GameObject lockScreenDeep;
    public GameObject unlockDeepButton;
    public GameObject visitDeepButton;

    public TextMeshProUGUI shopLevelText;

    float currentLevel;
    string unlockedCoral;
    string unlockedDeep;

    void OnEnable() {
        currentLevel = PlayerPrefs.GetFloat("expLevel");
        unlockedCoral = PlayerPrefs.GetString("unlockedCoral");
        unlockedDeep = PlayerPrefs.GetString("unlockedDeep");

        //Debug.Log(currentLevel + " " + unlockedCoral);

        shopLevelText.text = "" + currentLevel;
        if (SceneManager.GetActiveScene().name.Equals("MarineEnvironment"))
        {
            if (currentLevel >= 5 && unlockedCoral.Equals("no"))
            {
                unlockCoralButton.SetActive(true);
                visitCoralReefButton.SetActive(false);
            }

            if (currentLevel < 5)
            {
                PlayerPrefs.SetString("unlockedCoral", "no");
                unlockedCoral = "no";
            }

            if (currentLevel < 5 || unlockedCoral.Equals("no"))
            {
                lockScreenCoral.SetActive(true);
                visitCoralReefButton.SetActive(false);
            }

            if (unlockedCoral.Equals("yes"))
            {
                lockScreenCoral.SetActive(false);
                visitCoralReefButton.SetActive(true);
            }
        }

        if (SceneManager.GetActiveScene().name.Equals("MarineEnvironment") || SceneManager.GetActiveScene().name.Equals("CoralEnvironment"))
        {
            if (currentLevel >= 10 && unlockedDeep.Equals("no"))
            {
                unlockDeepButton.SetActive(true);
                visitDeepButton.SetActive(false);
            }

            if (currentLevel < 10)
            {
                PlayerPrefs.SetString("unlockedDeep", "no");
                unlockedDeep = "no";
            }

            if (currentLevel < 10 || unlockedDeep.Equals("no"))
            {
                lockScreenDeep.SetActive(true);
                visitDeepButton.SetActive(false);
            }

            if (unlockedDeep.Equals("yes"))
            {
                lockScreenDeep.SetActive(false);
                visitDeepButton.SetActive(true);
            }
        }

        if (SceneManager.GetActiveScene().name.Equals("CoralEnvironment")){
            visitMarineEnvironmentButton.SetActive(true);
            lockScreenCoral.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Equals("DeepSeaEnvironment"))
        {
            visitMarineEnvironmentButton.SetActive(true);
            visitCoralReefButton.SetActive(true);
            lockScreenCoral.SetActive(false);
            lockScreenDeep.SetActive(false);
        }
    }

    public void UnlockCoral() {
        lockScreenCoral.SetActive(false);
        unlockedCoral = "yes";
        PlayerPrefs.SetString("unlockedCoral", unlockedCoral);
        visitCoralReefButton.SetActive(true);
    }

    public void UnlockDeep()
    {
        lockScreenDeep.SetActive(false);
        unlockedDeep = "yes";
        PlayerPrefs.SetString("unlockedDeep", unlockedDeep);
        visitDeepButton.SetActive(true);
    }
}
