using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStepPlayer : MonoBehaviour
{
    public AudioClip[] playerStepSounds;
    private AudioSource audioSource;

    private void StepSoundsPlay()
    {
        audioSource.PlayOneShot(playerStepSounds[Random.Range(0, playerStepSounds.Length)]);
        Debug.Log("Звук шага");
    }
}
