using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoice : MonoBehaviour
{
    private bool firstChoose = false;
    private bool secondChoose = false;
    private GameObject FirstTrigger;
    private GameObject SecondTrigger;
    public GameObject ChoicePanel;
    public void FirstChoice()
    {
        firstChoose = true;
        ChoicePanel.SetActive(false);
        FirstTrigger.SetActive(true);
    }

    public void SecondChoice()
    {
        secondChoose = true;
        ChoicePanel.SetActive(false);
        SecondTrigger.SetActive(true); 
    }
}
