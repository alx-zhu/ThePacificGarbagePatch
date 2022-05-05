using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIFunctions : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    //public GameObject btn;
    public float textSize;
    public float tRate;
    //public float bRate = 0;
    //public float startTime = 2;
    public float switchTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.fontSize = textSize;
            //StartCoroutine(FluctuateSize(rate));
            InvokeRepeating("FluctuateText", switchTime, switchTime);
        }
        /*if (btn != null) {

        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FluctuateTextSize(1/tRate);
        //FluctuateBtnSize(bRate);
    }

    public void FluctuateTextSize(float r) {
        tmp.fontSize += r;
    }

    /*public void FluctuateBtnSize(float r) {
        btn.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, );
    }*/

    /*IEnumerator FluctuateSize(float rate) {
        yield return new WaitForSeconds(0.1f);
        tmp.fontSize += rate;
        StartCoroutine(FluctuateSize(rate));
    }*/

    public void FluctuateText() {
        tRate *= -1;
    }

    /*public void FluctuateBtn() {
        bRate *= -1;
    }*/

    public void SetTextSize(float size) {
        tmp.fontSize = size;
    }
}
