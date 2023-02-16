using UnityEngine;

public class SlimeAttack : EntityAttack
{
    public SlimeStats slimeStats;
  
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<CapsuleCollider2D>(); 
        attackOffset = transform.localPosition;
        entity = slimeStats;
        canHitTag = "Player";
    }

}