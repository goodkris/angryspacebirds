using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text insText;
    void Start()
    {
        insText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        insText.text =  "Instruction details hotkeys?";
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        insText.text = "Instruction";
    }
}