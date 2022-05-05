using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{
    public float level;
    public float exp;
    public float expToNextLevel = 50;
    public Slider expBar;
    //public TextMeshProUGUI currentLevel;
    //public TextMeshProUGUI expToNextLevelText;

    void OnEnable()
    {
        exp = PlayerPrefs.GetFloat("exp");
        level = PlayerPrefs.GetFloat("expLevel");
        expToNextLevel = level * 50;
        if (level < 5) {
            PlayerPrefs.SetString("unlockedCoral", "no");
        }
    }

    public void AddExp(float amt) {
        exp += amt;
        PlayerPrefs.SetFloat("exp", exp);
        //UpdateUI();
        CheckIfLevelUp();
    }

    public void SetLevel(float lvl)
    {
        level = lvl;
        expToNextLevel = 50 * level;
        exp = 0;
        PlayerPrefs.SetFloat("expLevel", level);
        PlayerPrefs.SetFloat("exp", exp);
    }

    public void AddLevel() {
        level++;
        expToNextLevel = 50 * level;
        exp = 0;
        PlayerPrefs.SetFloat("expLevel", level);
        PlayerPrefs.SetFloat("exp", exp);
    }

    public float GetExp()
    {
        return exp;
    }

    public float GetLevel()
    {
        return level;
    }

    public float GetExpToNextLevel() {
        expToNextLevel = level * 50;
        return expToNextLevel;
    }

    void CheckIfLevelUp() {
        while (exp >= expToNextLevel) {
            level++;
            PlayerPrefs.SetFloat("expLevel", level);
            exp = exp - expToNextLevel;
            PlayerPrefs.SetFloat("exp", exp);
            expToNextLevel = 50 * level;
            //UpdateUI();
        }
    }

    public void ResetPrefs() {
        PlayerPrefs.SetFloat("exp", 0);
        exp = 0;
        PlayerPrefs.SetFloat("expLevel", 1);
        level = 1;
        expToNextLevel = 50;
        //UpdateUI();
    }

    /*void UpdateUI()
    {
        expBar.value = exp / expToNextLevel;
        currentLevel.text = level.ToString();
        float temp = expToNextLevel - exp;
        expToNextLevelText.text = "" + temp;
    }*/

    void OnDisable()
    {
        PlayerPrefs.SetFloat("exp", exp);
        PlayerPrefs.SetFloat("expLevel", level);
    }
}
