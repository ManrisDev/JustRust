using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudio : MonoBehaviour
{
    public GameObject audioSourceOne;
    public GameObject audioSourceTwo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSourceOne.SetActive(false);
            audioSourceTwo.SetActive(true);
        }
            
    }
}
