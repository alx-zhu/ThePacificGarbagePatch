using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralAssetInstantiator : MonoBehaviour
{
    static CoralAssetInstantiator cInstance;

    public static CoralAssetInstantiator GetInstance()
    {
        return cInstance;
    }

    private void Awake()
    {
        cInstance = this;
    }

    //coral habitat fish
    public Component cSmallFish;
    public Component cAngelFish;
    public Component cGoldFish;
    public Component clownFish;


    //plastic objects
    public Component plasticCup;
    public Component plasticBottle;
}
