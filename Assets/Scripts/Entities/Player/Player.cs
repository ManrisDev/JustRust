using UnityEngine;

public class Player : Entity
{
    [Header("Characteristics")]
    [SerializeField] private float speed_ = 5f;
    [SerializeField] private float jumpForce = 15f; //Jump power

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private float direction;
    private bool isGrounded;
    private bool haveSword = true;

    private bool isRebirth = false;

    private float attackTime;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Start()
    {
        lives = 100;
        speed = speed_;
        damage = 25;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction > 0)
            transform.localScale = new Vector2(5, transform.localScale.y);
        else if (direction < 0)
            transform.localScale = new Vector2(-5, transform.localScale.y);

        if (isGrounded && attackTime < Time.time) State = States.idle;
        if (!isGrounded && attackTime < Time.time) State = States.jump;

        if (Input.GetButton("Horizontal"))
            Walk();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
        if (Input.GetKeyDown(KeyCode.J))
            AttackBottom();
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D (Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            if (attackTime < Time.time)
                State = States.jump;
            isGrounded = false;
        }
    }

    private void Walk()
    {
        if (isGrounded && attackTime < Time.time) 
        {
            if (haveSword)
                State = States.run_sword;
            else
                State = States.run;
        }
        FindObjectOfType<PlayerSounds>().PlayWalkSound();
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        FindObjectOfType<PlayerSounds>().PlayJumpSound();
    }

    public void AttackBottom()
    {
        attackTime = Time.time + 0.5f;
        State = States.attack_bottom;
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
