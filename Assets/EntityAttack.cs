using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    protected Vector2 attackOffset;
    protected Collider2D attackCollider;
    protected Entity entity;
    protected string canHitTag;
    public static int killed = 0;

    public void Attack()
    {
        transform.localPosition = attackOffset;
    }

    public void AttackInvers()
    {
        transform.localPosition = new Vector2(attackOffset.x * -1, attackOffset.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == canHitTag)
        {
            IDamagaeble damagaebleObject = collider.GetComponent<IDamagaeble>();

            if (damagaebleObject != null)
            {
                Vector2 parentPosition = gameObject.GetComponentInParent<Transform>().position;

                // Calculate direction between entity and target
                Vector2 direction = ((Vector2)collider.gameObject.transform.position - parentPosition).normalized;

                Vector2 knockback = direction * entity.KnockbackForce;
                
                damagaebleObject.OnHit(entity.Damage, knockback);

                if (damagaebleObject.Health <= 0 && collider.gameObject.tag == "Enemy")
                {
                    killed++;
                }
            }
        }

    }

   
   
}