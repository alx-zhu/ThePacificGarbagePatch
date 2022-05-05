using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineAssetInstantiator : MonoBehaviour
{
    static MarineAssetInstantiator instance;

    public static MarineAssetInstantiator GetInstance() {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    //ocean habitat fish
    public Component originalFish;
    public Component smallFish;
    public Component angelFish;
    public Component narrowFish;
    public Component goldFish;
    public Component dolphin;

    //coral fish
    public Component cSmallFish;
    public Component cAngelFish;
    public Component clownFish;
    public Component butterflyFish;
    public Component seahorse;

    //plastic objects
    public Component plasticCup;
    //public Component plasticBag;
    public Component plasticBottle;
    //public Component straw;
}
