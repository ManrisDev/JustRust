using System.Collections;
using UnityEngine;
using TMPro;

public class Introduction : MonoBehaviour
{
    public TMP_Text TextGameObject;
    private string text;
    [SerializeField] private float loadText;
    [SerializeField] private GameObject dialoguePanel;

    private void Start()
    {
        text = TextGameObject.text;
        TextGameObject.text = "";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        foreach(char abc in text)
        {
            TextGameObject.text += abc;
            yield return new WaitForSeconds(loadText);
        }
    }

    public void EndInt()
    {
        dialoguePanel.SetActive(true);
        FindObjectOfType<GameManager>().EndIntroduction();
    }
}