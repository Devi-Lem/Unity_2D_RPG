using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    public PlayerAttack playerAttack;
    public GameOverScreen  gameOverScreen;
    public UIScreen youWonScreen;
    public PauseScreen pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        entity = GetComponent<PlayerStats>();
        entityAttack = playerAttack;
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        if (Time.timeScale != 0f)
        {
            animator.SetTrigger("Attack");
        }
    }

    void OnPause()
    {
        if(pauseScreen.isActiveAndEnabled)
        {
            pauseScreen.ResumeButton();
        }
        else
        {
            pauseScreen.Trigger();
        }
    }

    public void OnDeath()
    {
        gameOverScreen.GameOver(playerAttack.GetKilled());
    }
    protected override void CanMove()
    {
        // if there is movement right or left then true, else false
        animator.SetBool("isMovingRightOrLeft", movementInput.x  >= 0.5f || movementInput.x <= -0.5f);
        // if there is movement up then true, else false
        animator.SetBool("isMovingUp", movementInput.y >= 0.5f);
        // if there is movement down then true, else false
        animator.SetBool("isMovingDown", movementInput.y <= -0.5f);
    }

    protected override void CantMove()
    {
        animator.SetBool("isMovingRightOrLeft", false);
        animator.SetBool("isMovingUp", false);
        animator.SetBool("isMovingDown", false);
    }

    void Update()
    {
        if (playerAttack.GetKilled() == 20)
        {
            youWonScreen.Trigger();
        }
    }
}
