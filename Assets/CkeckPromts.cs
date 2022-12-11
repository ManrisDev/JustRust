using UnityEngine;

public class CkeckPromts : MonoBehaviour
{
    Animator animator;

    bool step_1 = true;
    bool step_2;
    bool step_3;

    float delay;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (step_1)
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) 
            || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("step0");
                animator.SetTrigger("next");
                step_1 = false;
                step_2 = true;
            }
        if (step_2)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("step1");
                animator.SetTrigger("next");
                step_2 = false;
                step_3 = true;
            }
        if(step_3)
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("step2");
                animator.SetTrigger("next");
                step_3 = false;
                delay = Time.time + 4f;
            }
        else if (!step_1 && !step_2 && !step_3)
        if (Time.time > delay)
            animator.SetTrigger("next");
    }
}
