using UnityEngine;

public class PlayerStats: Killabel
{
    float 
    healthPoints = 100f,
    damagePoints = 10f,
    knockbackForce = 10f,
    moveSpeed = 1f;

    public HealthBar healthBarUI;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Health = healthPoints;
        Damage = damagePoints;
        KnockbackForce = knockbackForce;
        Speed = moveSpeed;
        canBeInvincible = true;
        healthBar = healthBarUI;
        
        healthBar.SetMaxHealth(healthPoints);
    }
}