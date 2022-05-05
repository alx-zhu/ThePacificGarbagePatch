using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool inside;
    public bool isInside() {
        return inside;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        inside = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        inside = false;
    }

}
