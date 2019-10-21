using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text creditsText;
    void Start()
    {
        creditsText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        creditsText.text = "Thank you NASA Space Apps! 🚀🚀🚀";
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        creditsText.text =  "Credits";
    }
}