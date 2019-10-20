using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    Button helpButton;
    GameObject wButton;
    GameObject iButton;
    GameObject cButton;
    bool toggleHide;

    void Start()
    {
        toggleHide = false;
        helpButton = GetComponent<Button>();
        helpButton.onClick.AddListener(TaskOnClick);
        wButton = GameObject.Find("WelcomeButton");
        iButton = GameObject.Find("InstButton");
        cButton = GameObject.Find("CreditsButton");
    }

    void TaskOnClick()
    {
        if (toggleHide)
        {
            wButton.SetActive(false);
            iButton.SetActive(false);
            cButton.SetActive(false);
        }
        else
        {
            wButton.SetActive(true);
            iButton.SetActive(true);
            cButton.SetActive(true);
        }
        toggleHide = !toggleHide;
    }
}