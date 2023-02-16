using UnityEngine;

public class PlayerAttack : EntityAttack
{
    public PlayerStats playerStats;
  
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<CapsuleCollider2D>(); 
        attackOffset = transform.localPosition;
        entity = playerStats;
        canHitTag = "Enemy";
    }

    public int GetKilled()
    {
        return killed;
    }
}
