using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Player")]
    //[SerializeField] private Hero movement;//
    [SerializeField] private Animator playerAnimator;

    [Header("Dialogue")]
    [SerializeField] private AudioSource dialogueAudio;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Animator dialogueAnimator;

    [Header("Game Manager")]
    [SerializeField] private GameManager gameManager;

    private Queue<string> Sentences;
    private Queue<AudioSource> Audio;
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
        Audio = new Queue<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnimator.SetBool("IsOpen", true);
        State = States.idle;
        //movement.enabled = false;//
        dialog = true;
        Sentences.Clear();
        Audio.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }

        foreach (AudioSource audio in dialogue.audio)
        {
            Audio.Enqueue(audio);
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
        AudioSource audio = Audio.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, audio));
    }

    IEnumerator TypeSentence(string sentence, AudioSource audio)
    {
        dialogueText.text = "";
        //dialogueAudio.AudioSource = audio;//
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
            DisplayNextSentence();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                gameManager.Pause();
                pause = true;
            }
            else
            {
                gameManager.Continue();
                if (dialog)
                    //movement.enabled = false;//
                pause = false;
            }
        }
    }
}

