using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoralFishManager : MonoBehaviour
{
    public int totalCoralFish;
    public int nCSmallFish;
    public int nCAngelFish;
    public int nClownFish;
    public int nButterflyFish;
    public int nSeahorse;
    public int maxFishCt = 20;

    public float smallFishCost = 10;
    public float angelFishCost = 20;
    public float clownFishCost = 30;
    public float butterflyFishCost = 25;
    public float seahorseCost = 40;

    public CoinCounter cc;

    //Buttons
    public Button smallFishButton;
    public Button angelFishButton;
    public Button clownFishButton;
    public Button butterflyFishButton;
    public Button seahorseButton;

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
        angelFishButton.interactable = true;
        smallFishButton.interactable = true;
        clownFishButton.interactable = true;
        butterflyFishButton.interactable = true;
        seahorseButton.interactable = true;

        totalCoralFish = PlayerPrefs.GetInt("totalCoralFish");

        nCSmallFish = PlayerPrefs.GetInt("nCSmallFish");
        for (int i = nCSmallFish; i > 0; i--)
        {
            Component cSmallFish = Instantiate(MarineAssetInstantiator.GetInstance().cSmallFish);
            cSmallFish.gameObject.SetActive(true);
        }

        nCAngelFish = PlayerPrefs.GetInt("nCAngelFish");
        for (int i = nCAngelFish; i > 0; i--)
        {
            Component cAngelFish = Instantiate(MarineAssetInstantiator.GetInstance().cAngelFish);
            cAngelFish.gameObject.SetActive(true);
        }

        nClownFish = PlayerPrefs.GetInt("nClownFish");
        for (int i = nClownFish; i > 0; i--)
        {
            Component clownFish = Instantiate(MarineAssetInstantiator.GetInstance().clownFish);
            clownFish.gameObject.SetActive(true);
        }

        nButterflyFish = PlayerPrefs.GetInt("nButterflyFish");
        for (int i = nButterflyFish; i > 0; i--)
        {
            Component butterflyFish = Instantiate(MarineAssetInstantiator.GetInstance().butterflyFish);
            butterflyFish.gameObject.SetActive(true);
        }

        nSeahorse = PlayerPrefs.GetInt("nSeahorse");
        for (int i = nSeahorse; i > 0; i--)
        {
            Component seahorse = Instantiate(MarineAssetInstantiator.GetInstance().seahorse);
            seahorse.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        //for testing click locations
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("x: " + Input.mousePosition.x + " y: " + Input.mousePosition.y);
        }*/

        totalCoralFish = PlayerPrefs.GetInt("totalCoralFish");
        currentLevel = PlayerPrefs.GetFloat("expLevel");

        if (cc.getCoins() < smallFishCost || totalCoralFish >= maxFishCt)
        {
            smallFishButton.interactable = false;
        }
        else
        {
            smallFishButton.interactable = true;
        }

        if (cc.getCoins() < angelFishCost || totalCoralFish >= maxFishCt)
        {
            angelFishButton.interactable = false;
        }
        else
        {
            angelFishButton.interactable = true;
        }

        if (cc.getCoins() < clownFishCost || totalCoralFish >= maxFishCt || currentLevel < 6)
        {
            clownFishButton.interactable = false;
        }
        else
        {
            clownFishButton.interactable = true;
        }

        if (cc.getCoins() < butterflyFishCost || totalCoralFish >= maxFishCt || currentLevel < 7)
        {
            butterflyFishButton.interactable = false;
        }
        else
        {
            butterflyFishButton.interactable = true;
        }

        if (cc.getCoins() < seahorseCost || totalCoralFish >= maxFishCt || currentLevel < 8)
        {
            seahorseButton.interactable = false;
        }
        else
        {
            seahorseButton.interactable = true;
        }

        fishRatio.text = totalCoralFish + " / " + maxFishCt;
    }

    //Add Functions

    public void AddSmallFish()
    {
        Component cSmallFish = Instantiate(MarineAssetInstantiator.GetInstance().cSmallFish);
        cSmallFish.gameObject.SetActive(true);
        nCSmallFish++;
        totalCoralFish++;
        PlayerPrefs.SetInt("nCSmallFish", nCSmallFish);
        PlayerPrefs.SetInt("totalCoralFish", totalCoralFish);
    }

    public void AddAngelFish()
    {
        Component cAngelFish = Instantiate(MarineAssetInstantiator.GetInstance().cAngelFish);
        cAngelFish.gameObject.SetActive(true);
        nCAngelFish++;
        totalCoralFish++;
        PlayerPrefs.SetInt("nCAngelFish", nCAngelFish);
        PlayerPrefs.SetInt("totalCoralFish", totalCoralFish);
    }

    public void AddClownFish()
    {
        Component clownFish = Instantiate(MarineAssetInstantiator.GetInstance().clownFish);
        clownFish.gameObject.SetActive(true);
        nClownFish++;
        totalCoralFish++;
        PlayerPrefs.SetInt("nClownFish", nClownFish);
        PlayerPrefs.SetInt("totalCoralFish", totalCoralFish);
    }

    public void AddButterflyFish()
    {
        Component butterflyFish = Instantiate(MarineAssetInstantiator.GetInstance().butterflyFish);
        butterflyFish.gameObject.SetActive(true);
        nButterflyFish++;
        totalCoralFish++;
        PlayerPrefs.SetInt("nButterflyFish", nButterflyFish);
        PlayerPrefs.SetInt("totalCoralFish", totalCoralFish);
    }

    public void AddSeahorse()
    {
        Component seahorse = Instantiate(MarineAssetInstantiator.GetInstance().seahorse);
        seahorse.gameObject.SetActive(true);
        nSeahorse++;
        totalCoralFish++;
        PlayerPrefs.SetInt("nSeahorse", nSeahorse);
        PlayerPrefs.SetInt("totalCoralFish", totalCoralFish);
    }

    //to reset fish numbers to 0
    public void ResetPrefs()
    {
        PlayerPrefs.SetInt("nCSmallFish", 0);
        nCSmallFish = 0;
        PlayerPrefs.SetInt("nCAngelFish", 0);
        nCAngelFish = 0;
        PlayerPrefs.SetInt("nClownFish", 0);
        nClownFish = 0;
        PlayerPrefs.SetInt("nButterflyFish", 0);
        nButterflyFish = 0;
        PlayerPrefs.SetInt("nSeahorse", 0);
        nSeahorse = 0;

        PlayerPrefs.SetInt("totalCoralFish", 0);
        totalCoralFish = 0;

    }

    void OnDisable()
    {
        /*totalSmallFish = FindObjectsOfType<SmallFish>();
        nCSmallFish = totalSmallFish.Length;
        PlayerPrefs.SetInt("nCSmallFish", nCSmallFish);*/

        nCSmallFish = PlayerPrefs.GetInt("nCSmallFish");
        nCAngelFish = PlayerPrefs.GetInt("nCAngelFish");
        nClownFish = PlayerPrefs.GetInt("nClownFish");
        nButterflyFish = PlayerPrefs.GetInt("nButterflyFish");
        nSeahorse = PlayerPrefs.GetInt("nSeahorse");

        totalCoralFish = nCSmallFish + nCAngelFish + nClownFish + nButterflyFish + nSeahorse;
        PlayerPrefs.SetInt("totalCoralFish", totalCoralFish);

        Debug.Log(nCSmallFish + " small fish; ");
        Debug.Log(nCAngelFish + " angel fish; ");
        Debug.Log(nClownFish + " clown fish; ");
        Debug.Log(nButterflyFish + " butterfly fish; ");
        Debug.Log(nSeahorse+ " seahorses; ");
        Debug.Log(totalCoralFish + " total fish.");

        PlayerPrefs.SetString("previousScene", "CoralEnvironment");
    }
}
