using UnityEngine;

public class Enemy : Entity
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        player.Take_Damage(25);
    }
}
