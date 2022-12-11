using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] AudioClip[] walk_sounds;
    [SerializeField] AudioClip[] die_sounds;
    [SerializeField] AudioClip[] jump_sounds;

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

    public void PlayJumpSound()
    {
        clip = jump_sounds[UnityEngine.Random.Range(0, jump_sounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}
