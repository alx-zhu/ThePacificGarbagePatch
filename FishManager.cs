using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishManager : MonoBehaviour
{
    public int totalFish;
    public int nOriginalFish;
    public int nSmallFish;
    public int nAngelFish;
    public int nNarrowFish;
    public int nGoldFish;
    public int nDolphin;
    public int maxFishCt = 15;

    public float originalFishCost = 5;
    public float smallFishCost = 10;
    public float angelFishCost = 20;
    public float narrowFishCost = 15;
    public float goldFishCost = 20;
    public float dolphinCost = 100;

    public CoinCounter cc;

    //Buttons
    public Button originalFishButton;
    public Button smallFishButton;
    public Button angelFishButton;
    public Button narrowFishButton;
    public Button goldFishButton;
    public Button dolphinButton;

    public TextMeshProUGUI fishRatio;

    float currentLevel;

    /*private static FishManager playerInstance;
    void Awake()
    {
        if (playerInstance == null)
        {
            DontDestroyOnLoad(this);
            playerInstance = this;
        }
    }*/

    //Adds in the stored number of each type of fish each time the fishManager is enabled
    void Start()
    {
        originalFishButton.interactable = true;
        angelFishButton.interactable = true;
        smallFishButton.interactable = true;
        narrowFishButton.interactable = true;
        goldFishButton.interactable = true;
        dolphinButton.interactable = true;

        totalFish = PlayerPrefs.GetInt("totalFish");
        currentLevel = PlayerPrefs.GetFloat("expLevel");

        nOriginalFish = PlayerPrefs.GetInt("nOriginalFish");
        for (int i = nOriginalFish; i > 0; i--)
        {
            Component originalFish = Instantiate(MarineAssetInstantiator.GetInstance().originalFish);
            originalFish.gameObject.SetActive(true);
        }

        nSmallFish = PlayerPrefs.GetInt("nSmallFish");
        for (int i = nSmallFish; i > 0; i--) {
            Component smallFish = Instantiate(MarineAssetInstantiator.GetInstance().smallFish);
            smallFish.gameObject.SetActive(true);
        }

        nAngelFish = PlayerPrefs.GetInt("nAngelFish");
        for (int i = nAngelFish; i > 0; i--)
        {
            Component angelFish = Instantiate(MarineAssetInstantiator.GetInstance().angelFish);
            angelFish.gameObject.SetActive(true);
        }

        nNarrowFish = PlayerPrefs.GetInt("nNarrowFish");
        for (int i = nNarrowFish; i > 0; i--)
        {
            Component narrowFish = Instantiate(MarineAssetInstantiator.GetInstance().narrowFish);
            narrowFish.gameObject.SetActive(true);
        }

        nGoldFish = PlayerPrefs.GetInt("nGoldFish");
        for (int i = nGoldFish; i > 0; i--)
        {
            Component goldFish = Instantiate(MarineAssetInstantiator.GetInstance().goldFish);
            goldFish.gameObject.SetActive(true);
        }

        nDolphin = PlayerPrefs.GetInt("nDolphin");
        for (int i = nDolphin; i > 0; i--)
        {
            Component dolphin = Instantiate(MarineAssetInstantiator.GetInstance().dolphin);
            dolphin.gameObject.SetActive(true);
        }
    }

    void Update() {
        //for testing click locations
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("x: " + Input.mousePosition.x + " y: " + Input.mousePosition.y);
        }*/

        totalFish = PlayerPrefs.GetInt("totalFish");
        currentLevel = PlayerPrefs.GetFloat("expLevel");

        if (cc.getCoins() < originalFishCost || totalFish >= maxFishCt)
        {
            originalFishButton.interactable = false;
        }
        else
        {
            originalFishButton.interactable = true;
        }

        if (cc.getCoins() < smallFishCost || totalFish >= maxFishCt)
        {
            smallFishButton.interactable = false;
        }
        else
        {
            smallFishButton.interactable = true;
        }

        if (cc.getCoins() < angelFishCost || totalFish >= maxFishCt || currentLevel < 2)
        {
            angelFishButton.interactable = false;
        }
        else
        {
            angelFishButton.interactable = true;
        }

        if (cc.getCoins() < narrowFishCost || totalFish >= maxFishCt || currentLevel < 3)
        {
            narrowFishButton.interactable = false;
        }
        else
        {
            narrowFishButton.interactable = true;
        }

        if (cc.getCoins() < goldFishCost || totalFish >= maxFishCt || currentLevel < 4)
        {
            goldFishButton.interactable = false;
        }
        else
        {
            goldFishButton.interactable = true;
        }

        if (cc.getCoins() < dolphinCost || PlayerPrefs.GetInt("nDolphin") >= 1 || currentLevel < 5) //max of 1 dolphin
        {
            dolphinButton.interactable = false;
        }
        else
        {
            dolphinButton.interactable = true;
        }

        fishRatio.text = totalFish + " / " + maxFishCt;
    }

    //Add Functions
    public void AddOriginalFish()
    {
        Component originalFish = Instantiate(MarineAssetInstantiator.GetInstance().originalFish);
        originalFish.gameObject.SetActive(true);
        nOriginalFish++;
        totalFish++;
        PlayerPrefs.SetInt("nOriginalFish", nOriginalFish);
        PlayerPrefs.SetInt("totalFish", totalFish);
    }

    public void AddSmallFish() {
        Component smallFish = Instantiate(MarineAssetInstantiator.GetInstance().smallFish);
        smallFish.gameObject.SetActive(true);
        nSmallFish++;
        totalFish++;
        PlayerPrefs.SetInt("nSmallFish", nSmallFish);
        PlayerPrefs.SetInt("totalFish", totalFish);
    }

    public void AddAngelFish()
    {
        Component angelFish = Instantiate(MarineAssetInstantiator.GetInstance().angelFish);
        angelFish.gameObject.SetActive(true);
        nAngelFish++;
        totalFish++;
        PlayerPrefs.SetInt("nAngelFish", nAngelFish);
        PlayerPrefs.SetInt("totalFish", totalFish);
    }

    public void AddNarrowFish()
    {
        Component narrowFish = Instantiate(MarineAssetInstantiator.GetInstance().narrowFish);
        narrowFish.gameObject.SetActive(true);
        nNarrowFish++;
        totalFish++;
        PlayerPrefs.SetInt("nNarrowFish", nNarrowFish);
        PlayerPrefs.SetInt("totalFish", totalFish);
    }

    public void AddGoldFish()
    {
        Component goldFish = Instantiate(MarineAssetInstantiator.GetInstance().goldFish);
        goldFish.gameObject.SetActive(true);
        nGoldFish++;
        totalFish++;
        PlayerPrefs.SetInt("nGoldFish", nGoldFish);
        PlayerPrefs.SetInt("totalFish", totalFish);
    }

    public void AddDolphin()
    {
        Component dolphin = Instantiate(MarineAssetInstantiator.GetInstance().dolphin);
        dolphin.gameObject.SetActive(true);
        nDolphin++;
        PlayerPrefs.SetInt("nDolphin", nDolphin);
        PlayerPrefs.SetInt("totalFish", totalFish);
    }

    //to reset fish numbers to 0
    public void ResetPrefs()
    {
        PlayerPrefs.SetInt("nOriginalFish", 0);
        nOriginalFish = 0;
        PlayerPrefs.SetInt("nSmallFish", 0);
        nSmallFish = 0;
        PlayerPrefs.SetInt("nAngelFish", 0);
        nAngelFish = 0;
        PlayerPrefs.SetInt("nNarrowFish", 0);
        nNarrowFish = 0;
        PlayerPrefs.SetInt("nGoldFish", 0);
        nGoldFish = 0;
        PlayerPrefs.SetInt("nDolphin", 0);
        nDolphin = 0;
        PlayerPrefs.SetInt("totalFish", 0);
        totalFish = 0;
    }

    void OnDisable()
    {
        /*totalSmallFish = FindObjectsOfType<SmallFish>();
        nSmallFish = totalSmallFish.Length;
        PlayerPrefs.SetInt("nSmallFish", nSmallFish);*/

        nOriginalFish = PlayerPrefs.GetInt("nOriginalFish");
        nSmallFish = PlayerPrefs.GetInt("nSmallFish");
        nAngelFish = PlayerPrefs.GetInt("nAngelFish");
        nNarrowFish = PlayerPrefs.GetInt("nNarrowFish");
        nGoldFish = PlayerPrefs.GetInt("nGoldFish");
        nDolphin = PlayerPrefs.GetInt("nDolphin");

        totalFish = nOriginalFish + nSmallFish + nAngelFish + nNarrowFish + nGoldFish;
        PlayerPrefs.SetInt("totalFish", totalFish);

        Debug.Log(nOriginalFish + " original fish; ");
        Debug.Log(nSmallFish + " small fish; ");
        Debug.Log(nAngelFish + " angel fish; ");
        Debug.Log(nNarrowFish + " narrow fish; ");
        Debug.Log(nGoldFish + " gold fish; ");
        Debug.Log(nDolphin + " dolphins; ");
        Debug.Log(totalFish + " total fish.");

        PlayerPrefs.SetString("previousScene", "MarineEnvironment");
    }
}
