using UnityEngine;

public class SoundsRobot : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] AudioClip[] die_sounds;
    [SerializeField] AudioClip[] walk_sounds;
    [SerializeField] AudioClip[] attack_sounds;

    private AudioSource audioSource;

    private AudioClip clip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkSound()
    {
        clip = walk_sounds[UnityEngine.Random.Range(0, walk_sounds.Length)];
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(clip);
    }

    public void PlayDieSound()
    {
        clip = die_sounds[UnityEngine.Random.Range(0, die_sounds.Length)];
        audioSource.PlayOneShot(clip);
    }

    public void PlayAttackSound()
    {
        clip = attack_sounds[UnityEngine.Random.Range(0, attack_sounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}
