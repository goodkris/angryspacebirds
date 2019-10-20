using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResButton : MonoBehaviour
{
    Button resButton;

    void Start()
    {
        resButton = GetComponent<Button>();
        resButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.OpenURL("https://solarsystem.nasa.gov/basics/chapter3-2");
    }
}