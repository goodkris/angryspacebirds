using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WelcomeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text welcomeText;
    void Start()
    {
        welcomeText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        welcomeText.text =  "The game introduction";
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        welcomeText.text = "Welcome";
    }
}