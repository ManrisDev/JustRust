using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoice : MonoBehaviour
{
    public bool firstChoose = false;
    public bool secondChoose = false;
    [SerializeField] private GameObject FirstTrigger;
    [SerializeField] private GameObject SecondTrigger;
    public GameObject ChoicePanel;
    public void FirstChoice()
    {
        Debug.Log("Выбран первый триггер");
        firstChoose = true;
        ChoicePanel.SetActive(false);
        FirstTrigger.SetActive(true);
    }

    public void SecondChoice()
    {
        Debug.Log("Выбран второй триггер");
        secondChoose = true;
        ChoicePanel.SetActive(false);
        SecondTrigger.SetActive(true); 
    }
}
