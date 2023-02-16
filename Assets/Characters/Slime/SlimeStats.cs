using UnityEngine;

public class SlimeStats: Killabel
{
    float 
    healthPoints = 20f,
    damagePoints = 10f,
    knockbackForce = 5f,
    moveSpeed = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Health = healthPoints;
        Damage = damagePoints;
        KnockbackForce = knockbackForce;
        Speed = moveSpeed;
    }
}