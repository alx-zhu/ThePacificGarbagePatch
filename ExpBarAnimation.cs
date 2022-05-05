using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBarAnimation : MonoBehaviour
{
    public float level;
    public float exp;
    public float expToNextLevel;

    public ExpManager expManager;
    public Slider expBar;
    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI expUntilNextLevelText;
    public ParticleSystem pSystem;


    // Start is called before the first frame update
    void OnEnable()
    {
        //expToNextLevel = expManager.GetExpToNextLevel();

        //to get the exp and level values before exp changes were made outside of the scene
        //allows the animation to start at the previous value instead of 0 every time
        exp = PlayerPrefs.GetFloat("expNA");
        level = PlayerPrefs.GetFloat("expLevelNA");
        expToNextLevel = level * 50;

        expBar.value = exp / expToNextLevel;

        currentLevel.text = "" + level;
        float temp = expToNextLevel - exp;
        expUntilNextLevelText.text = "" + temp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (level < expManager.GetLevel())
        {
            //can also use PlayerPrefs.GetFloat("expLevel")
            //if level is less than actual level
            AddExperience();
            UpdateUI();
        }
        else if (exp < expManager.GetExp())
        {
            //if level is equal but exp is still less than the actual value
            AddExperience();
            UpdateUI();
        }
    }

    void AddExperience() {
        exp++;
        if (exp >= expToNextLevel) {
            level++;
            exp = 0;
            LevelUp();
        }
    }

    void UpdateUI() {
        expBar.value = exp / expToNextLevel;
        currentLevel.text = level.ToString();
        float temp = expToNextLevel - exp;
        expUntilNextLevelText.text = "" + temp;
    }

    void LevelUp() {
        expToNextLevel = 50*level;
    }

    public void ResetPrefs() {
        exp = 0;
        level = 1;
        PlayerPrefs.SetFloat("expNA", exp);
        PlayerPrefs.SetFloat("expLevelNA", level);
        expToNextLevel = 50;
        UpdateUI();
    }

    public void SetLevel(float lvl) {
        level = lvl;
        expToNextLevel = level * 50;
        exp = 0;
        UpdateUI();
    }

    public void AddLevel() {
        level++;
        expToNextLevel = level * 50;
        exp = 0;
        UpdateUI();
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("expNA", exp);
        PlayerPrefs.SetFloat("expLevelNA", level);
    }
}
