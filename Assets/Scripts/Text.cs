using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text : MonoBehaviour
{
    public TMP_Text TextGameObject;
    private string text;
    [SerializeField] private float loadText;

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
}
