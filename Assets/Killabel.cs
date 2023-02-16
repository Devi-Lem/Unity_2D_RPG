using UnityEngine;

public class Killabel : Entity, IDamagaeble
{
    public void OnHit(float damage, Vector2 knockback)
    {
        if (!Invincible)
        {
            rb.AddForce(knockback);
            Health -= damage;
        }

        if(canBeInvincible)
        {
            Invincible = true;
        }

    }

    public void OnHit(float damage)
    {
         if (!Invincible)
        {
            Health -= damage;
        }

        if(canBeInvincible)
        {
            Invincible = true;
        }
    }

   public void RemoveEntity()
   {
        Destroy(gameObject);
   }

   void FixedUpdate()
   {
    if (Invincible)
    {
        invincibilityTimeElapse += Time.deltaTime;
        if (invincibilityTimeElapse > invincibilityTime)
        {
            Invincible = false;
        }
        
    }
   }
}
   
