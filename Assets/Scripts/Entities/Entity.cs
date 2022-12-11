using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    protected int lives = 10; //Lives count
    protected int damage = 5;
    protected float speed = 5f;

    public virtual void Take_Damage(int lost_lives)
    {
        this.lives -= lost_lives;

        if (this.lives < 1)
        {
            this.Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}

public enum States
{
    idle,
    run,
    run_sword,
    jump,
    attack_bottom,
}