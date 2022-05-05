using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlasticsManager : MonoBehaviour
{
    //public TestLevelController lControl;

    //public int completedLevelSTF;

    float respawnTimeCup;
    bool cupAlreadyActive;
    string stfComplete;

    float respawnTimeBottle;
    bool bottleAlreadyActive;
    string dtpComplete;

    public float partialTime = 10;
    public float fullTime = 30;

    /*private static PlasticsManager playerInstance;
    void Awake()
    {
        if (playerInstance == null)
        {
            DontDestroyOnLoad(this);
            playerInstance = this;
        }
    }*/

    // Start is called before the first frame update
    void OnEnable()
    {
        //respawnTimeCup = Random.Range(2f, 5f);
        //cupAlreadyActive = true;
        //timeAlreadySet = false;
        stfComplete = PlayerPrefs.GetString("stfComplete");
        CheckIfSTFGameCompleteAndSetRespawn();
        CheckIfDTPCompleteAndSetRespawn();
        Debug.Log(respawnTimeCup + " seconds until cup respawns");
        Debug.Log(respawnTimeBottle + " seconds until bottle respawns");
        dtpComplete = PlayerPrefs.GetString("dtpComplete");
    }

    // Update is called once per frame
    void Update()
    {
        CreatePlasticCup();
        CreatePlasticBottle();
    }

    void CreatePlasticCup() {
        if (respawnTimeCup <= 0 && cupAlreadyActive == false)
        {
            Component plasticCup = Instantiate(MarineAssetInstantiator.GetInstance().plasticCup);
            plasticCup.gameObject.SetActive(true);
            plasticCup.transform.position = new Vector3(Random.Range(-8f, 8f), 4.5f, -2);

            cupAlreadyActive = true;

        }
        if (!cupAlreadyActive)
        {
            if (respawnTimeCup > 0)
            {
                respawnTimeCup -= Time.deltaTime;
            }
        }

    }

    void CreatePlasticBottle()
    {
        if (respawnTimeBottle <= 0 && bottleAlreadyActive == false)
        {
            Component plasticBottle = Instantiate(MarineAssetInstantiator.GetInstance().plasticBottle);
            plasticBottle.gameObject.SetActive(true);
            plasticBottle.transform.position = new Vector3(Random.Range(-5f, 5f), 5f, -2);

            bottleAlreadyActive = true;
        }
        if (!bottleAlreadyActive)
        {
            if (respawnTimeBottle > 0)
            {
                respawnTimeBottle -= Time.deltaTime;
            }
        }
    }

    void CheckIfSTFGameCompleteAndSetRespawn()
    {
        stfComplete = PlayerPrefs.GetString("stfComplete");
        if (stfComplete.Equals("stfComplete"))
        {
            respawnTimeCup = fullTime;
            stfComplete = "";
            PlayerPrefs.SetString("stfComplete", stfComplete);
        }
        else
        {
            respawnTimeCup = 0;
            stfComplete = "";
            PlayerPrefs.SetString("stfComplete", stfComplete);
        }
    }

    void CheckIfDTPCompleteAndSetRespawn() {
        dtpComplete = PlayerPrefs.GetString("dtpComplete");
        if (dtpComplete.Equals("dtpPartial"))
        {
            respawnTimeBottle = partialTime;
            dtpComplete = "";
            PlayerPrefs.SetString("dtpComplete", dtpComplete);
        }
        else if (dtpComplete.Equals("dtpComplete")) {
            respawnTimeBottle = fullTime;
            dtpComplete = "";
            PlayerPrefs.SetString("dtpComplete", dtpComplete);
        }
    }

    /*float CheckIfGameCompleteAndSetRespawn() {
        lControl = FindObjectOfType<TestLevelController>();
        if (lControl != null && !timeAlreadySet)
        {
            if (lControl.stfComplete)
            {
                //Destroy(plasticCup.gameObject);
                cupAlreadyActive = false;
                //respawnTimeCup = 10;
                //timeAlreadySet = true;
                //Debug.Log(respawnTimeCup);
                return 10;
            }
            else
            {
                cupAlreadyActive = false;
                //respawnTimeCup = 0;
                //timeAlreadySet = true;
                //Debug.Log(respawnTimeCup);
                return 1;
            }
        }
        else if (lControl == null) {
            //respawnTimeCup = 0;
            return 1;
        }
        return 1;
    }*/


}
