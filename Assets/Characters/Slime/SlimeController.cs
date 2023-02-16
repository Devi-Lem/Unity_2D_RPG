using UnityEngine;

public class SlimeController : EntityController
{
    //public SlimeAttack slimeAttack;
    public DetectionZone detectionZone, attackingZone;
    public SlimeAttack slimeAttack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        entity = GetComponent<SlimeStats>();
        hasAttackDelay = true;
        entityAttack = slimeAttack;
    }

    void Update()
    {
        // Attack the player if in range
        if (attackingZone.detectedObjs.Count > 0 && CanAttack)
        {
            CanMove();
            animator.SetTrigger("Attack");
            CanAttack = false;
        }
        // Move toward a player
        else if (detectionZone.detectedObjs.Count > 0)//Do see a player
        {
            Collider2D detectedObj = detectionZone.detectedObjs[0];

            // Calculate diretion to target object
            Vector2 direction = (detectedObj.transform.position - transform.position);

            if (direction.magnitude <= attackingZone.collisonRadius)
            {
                // Stop before the object
                CantMove();
            }
            else
            {
                // Move towards detected object
                movementInput = direction.normalized;
            }
        }
        else//Don't see a player
        {
            CantMove();
        }

        
    }
}
