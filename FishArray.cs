using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishArray : MonoBehaviour
{
    /*private static FishArray playerInstance;
    static GameObject[] fishArray =  new GameObject[10];
    int index;

    FishSpecies[] fishSpecies;
    AngelFish[] angelFish;
    SmallFish[] smallFish;
    //GoldFish[] goldFish;
    Dolphin[] dolphin;

    void Awake()
    {
        if (playerInstance == null)
        {
            DontDestroyOnLoad(this);
            playerInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        index = 1;
        fishSpecies = FindObjectsOfType<FishSpecies>();
        angelFish = FindObjectsOfType<AngelFish>();
        smallFish = FindObjectsOfType<SmallFish>();
        //goldFish = FindObjectsOfType<GoldFish>();
        dolphin = FindObjectsOfType<Dolphin>();

        FindAllActive();

        if (fishArray.Length > 1)
        {
            for (int i = 0; i < fishArray.Length; i++)
            {
                fishArray[i].SetActive(true);
            }
        }
    }

    void OnDisable()
    {
        FindAllActive();
    }

    void FindAllActive() {
        foreach (var s1 in fishSpecies)
        {
            if (s1.gameObject.activeSelf)
            {
                fishArray[index] = s1.gameObject;
                index++;
            }
        }
        foreach (var aF in angelFish)
        {
            if (aF.gameObject.activeSelf)
            {
                fishArray[index] = aF.gameObject;
                index++;
            }
        }
        foreach (var sF in smallFish)
        {
            if (sF.gameObject.activeSelf)
            {
                fishArray[index] = sF.gameObject;
                index++;
            }
        }
        foreach (var gF in goldFish)
        {
            if (gF.gameObject.activeSelf)
            {
                fishArray[index] = gF.gameObject;
                index++;
            }
        foreach (var dP in dolphin)
        }
        {
            if (dP.gameObject.activeSelf)
            {
                fishArray[index] = dP.gameObject;
                index++;
            }
        }
    }*/
}
