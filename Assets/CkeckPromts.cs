using UnityEngine;

public class CkeckPromts : MonoBehaviour
{
    Animator animator;

    bool step_1 = true;
    bool step_2, step_3, step_4;

    float delay;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void End()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (step_1)
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) 
            || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetTrigger("next");
                step_1 = false;
                step_2 = true;
            }
        if (step_2)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("next");
                step_2 = false;
                step_3 = true;
            }
        if(step_3)
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            {
                animator.SetTrigger("next");
                step_3 = false;
                step_4 = true;
            }
        if(step_4)
            animator.SetTrigger("next");
            step_4 = false;
    }
}
