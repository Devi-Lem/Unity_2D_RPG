using UnityEngine;

public interface IDamagaeble
{
    public float Health {set; get;}
    public void OnHit(float damage, Vector2 knockback);

    public void OnHit(float damage);
}