using UnityEngine;

public class Player : Entity
{
    [Header("Characteristics")]
    [SerializeField] private float walkSpeed = 3f; //Movement speed
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpForce = 15f; //Jump power

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private float direction;
    private bool isGrounded;
    private bool isFight = false;

    private bool isRebirth = false;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Start()
    {
        lives = 25;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction > 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else if (direction < 0)
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);

        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            if (isFight) {
                Run();
            }
            else {
                Walk();
            }
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D (Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            State = States.jump;
            isGrounded = false;
        }
    }

    private void Walk()
    {
        if (isGrounded) State = States.walk;
        FindObjectOfType<PlayerSounds>().PlayWalkSound();
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, walkSpeed * Time.deltaTime);
    }

    private void Run()
    {
        if (isGrounded) State = States.run;
        FindObjectOfType<PlayerSounds>().PlayRunSound();
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, runSpeed * Time.deltaTime);
        //sprite.flipX = direction.x < 0f;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        FindObjectOfType<PlayerSounds>().PlayJumpSound();
    }

    public override void Take_Damage(int lost_lives)
    {
        int remaining_lives = lives - lost_lives;
        animator.SetTrigger("damage");
        while (lives > remaining_lives)
        {
            lives--;
            if (lives == 0)
            {
                FindObjectOfType<PlayerSounds>().PlayDieSound();
                if (!isRebirth) {
                    FindObjectOfType<GameManager>().RebirthOrDie();
                    lives = GlobalVar.Get_lives();
                    isRebirth = true;
                }
                else 
                    FindObjectOfType<GameManager>().EndGame();
                break;
            }
        }
        GlobalVar.Set_lives(lives);
        Debug.Log(lives);
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
