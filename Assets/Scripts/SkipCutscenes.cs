using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutscenes : MonoBehaviour
{
    [SerializeField] private float loadTime;
    [SerializeField] GameObject TextPanel;
    void Start()
    {
        StartCoroutine(FirstCutscenes());
    }

    IEnumerator FirstCutscenes()
    {
        yield return new WaitForSeconds(loadTime);
        TextPanel.SetActive(false);
        
    }
}
