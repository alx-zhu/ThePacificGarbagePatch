using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public float coinCount = 0;
    //public Manager mgr;
    //public CoinCounter otherCounter;

    public bool save;

    public GameObject coinCounterObject;

    void OnEnable()
    {
        coinCount = PlayerPrefs.GetFloat("coins");
        if (coinText != null)
        {
            UpdateText();
        }


        if (save)
        {
            DontDestroyOnLoad(coinCounterObject);
        }
    }

    public void addCoins(float coins)
    {
        coinCount += coins;
        PlayerPrefs.SetFloat("coins", coinCount);
        UpdateText();
    }

    public void spendCoins(float cost) {
        if (checkIfEnough(cost))
        {
            coinCount -= cost;
            PlayerPrefs.SetFloat("coins", coinCount);
            UpdateText();
        }
        else
            Debug.Log("Not Enough Coins");
    }

    public float getCoins() {
        return coinCount;
    }

    public bool checkIfEnough(float cost) {
        if (cost <= coinCount)
        {
            return true;
        }
        else {
            return false;
        }
    }

    public void resetPlayerPrefs() {
        PlayerPrefs.SetFloat("coins", 0);
        coinCount = 0;
        UpdateText();
    }

    public void UpdateText() {
        coinCount = PlayerPrefs.GetFloat("coins");
        coinText.text = coinCount.ToString();
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("coins", coinCount);
        
    }

    /*public void copyCoinAmt(CoinCounter otherCoinCounter) {
        coinCount = otherCoinCounter.getCoins();
        coinText.text = coinCount.ToString();
    }*/
}
