using UnityEngine;

public class Entity : MonoBehaviour
{

    protected Animator animator;
    protected Rigidbody2D rb;
    protected HealthBar healthBar = null;
    
    protected float invincibilityTime = 0.5f, invincibilityTimeElapse = 0;
    protected bool canBeInvincible = false;
    bool _invincible = false;

    float 
    _health = 0,
    _damage = 0,
    _knockbackForce = 0,
    _speed = 0;
    

    public float Health
    {
        set
        {
            if(_health > value) 
            {
                animator.SetTrigger("Hurt");

            }

            _health = value;

            if (healthBar != null)
            {
                healthBar.SetHealth(_health); 
            }
            
            if(_health<=0)
            {
                animator.SetTrigger("Defeated");
                rb.simulated = false;
            }
        }
        get
        {
            return _health;
        }
    }

    public float Damage
    {
        set
        {
            _damage = value;
        }

        get
        {
            return _damage;
        }
    }

    public float KnockbackForce
    {
        set
        {
            _knockbackForce = value * 100f;
        }

        get
        {
            return _knockbackForce;
        }
    }

    public float Speed
    {
        set
        {
            _speed = value;
        }

        get
        {
            return _speed;
        }
    }

    public bool Invincible
    {
        set
        {
            _invincible = value;

            if (_invincible == true)
            {
                invincibilityTimeElapse = 0;
            }
        }

        get
        {
            return _invincible;
        }
    }
}