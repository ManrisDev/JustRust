using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Player")]
    //[SerializeField] private Hero movement;//
    [SerializeField] private Animator playerAnimator;

    [Header("Dialogue")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Animator dialogueAnimator;
    [SerializeField] private AudioSource dialogueSource;

    [SerializeField] private GameObject dialoguePanel;

    [Header("Game Manager")]
    //[SerializeField] public GameManager gameManager;//
    private Queue<AudioClip> Audio;
    private Queue<string> Sentences;
    private bool pause = false;
    private bool dialog = false;

    private States State
    {
        get { return (States)playerAnimator.GetInteger("state"); }
        set { playerAnimator.SetInteger("state", (int)value); }
    }

    void Start()
    {
        Sentences = new Queue<string>();
        Audio = new Queue<AudioClip>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialoguePanel.SetActive(true);
        dialogueAnimator.SetBool("IsOpen", true);
        State = States.idle;
        //movement.enabled = false;//
        dialog = true;
        Sentences.Clear();
        Audio.Clear();

        foreach (AudioClip audio in dialogue.audio)
        {
            Audio.Enqueue(audio);
        }
        foreach (string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = Sentences.Dequeue();
        AudioClip audio = Audio.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, audio));
    }

    IEnumerator TypeSentence(string sentence, AudioClip audio)
    {
        dialogueText.text = "";
        dialogueSource.clip = audio;
        dialogueSource.PlayOneShot(dialogueSource.clip);
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        //movement.enabled = true;//
        dialog = false;
        dialogueAnimator.SetBool("IsOpen", false);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueSource.Stop();
            DisplayNextSentence();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
               // gameManager.Pause();//
                pause = true;
            }
            else
            {
                //gameManager.Continue();//
                if (dialog)
                    //movement.enabled = false;//
                pause = false;
            }
        }
    }
}

