using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    protected Vector2 movementInput;
    protected Rigidbody2D rb;
    protected CapsuleCollider2D capsuleCollider2D;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected EntityAttack entityAttack;
    protected Entity entity;
    protected bool hasAttackDelay = false;
    protected float attackDelayTime = 2f, attackDelayTimeElapse = 0;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    LayerMask mask;
    ContactFilter2D movementFilter;
    float fixedMoveSpeed,  collisionOffset = 0.05f;
    bool 
    canMove = true, 
    success = true, 
    _canAttack = true;

    public bool CanAttack
    {
        set
        {
            _canAttack = value;

            if (_canAttack == false)
            {
                attackDelayTimeElapse = 0;
            }
        }

        get
        {
            return _canAttack;
        }
    }


    void Awake()
    {
        //Setting filter for Walls in Raycast
        mask = LayerMask.GetMask("Wall");
        movementFilter.SetLayerMask(mask);
    }

    void FixedUpdate()
    {
        // If movement input is not 0, try to move
        if (movementInput != Vector2.zero && canMove)
        {
            success = TryMove(movementInput);

            if(!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
            }
            if(!success)
            {
                success = TryMove(new Vector2(0, movementInput.y));
            }
            

            // Set direction of sprite to movement direction
            if(success)
            {
                CanMove();
            }
            else
            {
                CantMove();
            }

            if (movementInput.x < 0) // Moving left
            {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x >= 0) // Moving right
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            CanMove();
        }

        // If enetity have delay between attacks
        if(hasAttackDelay)
        {
            if (!CanAttack)
            {
                attackDelayTimeElapse += Time.deltaTime;
                if (attackDelayTimeElapse > attackDelayTime)
                {
                    CanAttack = true;
                }
            
            }
        }
    }

    public bool TryMove(Vector2 direction)
    {
        fixedMoveSpeed = entity.Speed * Time.fixedDeltaTime;

        if (direction != Vector2.zero)
        {
            //Check for potential collisions
            int count = capsuleCollider2D.Cast(
                direction, // X and Y values between -1 and 1 repressent the direction from the body to look for collsions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                fixedMoveSpeed + collisionOffset // The amount to cast equal to the movement plus an offset
            );

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * fixedMoveSpeed);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {// Can't move if there's no direction to move in
            return false;
        }
    }

    protected virtual void CanMove()
    {
        // if there is movement right or left then true, else false
        animator.SetBool("isMovingRightOrLeft", true);
    }

    protected virtual void CantMove()
    {
        animator.SetBool("isMovingRightOrLeft", false);
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    public void EntityAttack()
    {
        if (spriteRenderer.flipX == true)
        {
            entityAttack.AttackInvers();
        }
        else
        {
            entityAttack.Attack();
        }
    }
}