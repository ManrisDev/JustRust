using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    protected int lives = 5; //Lives count

    public virtual void Take_Damage(int lost_lives)
    {
        lives -= lost_lives;
        Debug.Log(this.gameObject.name + " lives: " + lives);

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
    walk,
    run,
    jump
}