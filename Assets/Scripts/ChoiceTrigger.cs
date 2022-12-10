using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceTrigger : MonoBehaviour
{
    public GameObject ChoicePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChoicePanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
