using System.Collections;
using UnityEngine;
using TMPro;

public class Introduction : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject introductionPanel;
    [SerializeField] GameObject firstTrigger;

    [SerializeField] TMP_Text introductionText;
    [SerializeField] float textSpeed;
    
    private string text;

    private void Start()
    {
        text = introductionText.text;
        introductionText.text = "";
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
        foreach(char abc in text)
        {
            introductionText.text += abc;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void EndIntroduction()
    { 
        player.enabled = true;
        introductionPanel.SetActive(false);
        firstTrigger.SetActive(true);
    }
}
