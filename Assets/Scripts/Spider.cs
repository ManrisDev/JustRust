using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : Entity
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    public bool isRun = false;
    public AudioSource audioSource;
    private float distance;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < distanceBetween)
        {
            isRun = true;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (audioSource.isPlaying) return;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        
    }
}


