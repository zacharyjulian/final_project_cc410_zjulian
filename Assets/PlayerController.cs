// referenced from Chris' Tutorials 2D Game Tutorial
// https://www.youtube.com/watch?v=7iYWpzL9GkM&t=73s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// PlayerController class.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public int coins;
    public int health;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    /// <summary>
    /// Begins a sword attack.
    /// </summary>
    public void SwordAttack()
    {
        this.LockMovement();

        if (this.spriteRenderer.flipX == true)
        {
            this.swordAttack.AttackLeft();
        }
        else
        {
            this.swordAttack.AttackRight();
        }
    }

    /// <summary>
    /// Stops a sword attack.
    /// </summary>
    public void EndSwordAttack()
    {
        this.UnlockMovement();
        this.swordAttack.StopAttack();
    }

    /// <summary>
    /// Locks player movement.
    /// </summary>
    public void LockMovement()
    {
        this.canMove = false;
    }

    /// <summary>
    /// Unlocks player movement.
    /// </summary>
    public void UnlockMovement()
    {
        this.canMove = true;
    }

    /// <summary>
    /// Called on a fixed set of time instead of every frame.
    /// </summary>
    private void FixedUpdate()
    {
        if (this.canMove)
        {
            // If movement input is not 0, try to move
            if (this.movementInput != Vector2.zero)
            {

                bool success = this.TryMove(this.movementInput);

                if (!success)
                {
                    success = this.TryMove(new Vector2(this.movementInput.x, 0));
                }

                if (!success)
                {
                    success = this.TryMove(new Vector2(0, this.movementInput.y));
                }

                this.animator.SetBool("isMoving", success);
            }
            else
            {
                this.animator.SetBool("isMoving", false);
            }

            // Set direction of sprite to movement direction
            if (this.movementInput.x < 0)
            {
                this.spriteRenderer.flipX = true;
            }
            else if (this.movementInput.x > 0)
            {
                this.spriteRenderer.flipX = false;
            }
        }
    }

    /// <summary>
    /// Checks to see if there is an item blocking the player and moves if not.
    /// </summary>
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            // Check for potential collisions
            int count = this.rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                this.movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                this.castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                this.moveSpeed * Time.fixedDeltaTime + this.collisionOffset); // The amount to cast equal to the movement plus an offset

            if (count == 0)
            {
                this.rb.MovePosition(this.rb.position + direction * this.moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            // Can't move if there's no direction to move in
            return false;
        }
    }

    /// <summary>
    /// Detects when the controller is moving.
    /// </summary>
    void OnMove(InputValue movementValue)
    {
        this.movementInput = movementValue.Get<Vector2>();
    }

    /// <summary>
    /// Detects when the controller attacks.
    /// </summary>
    void OnFire()
    {
        this.animator.SetTrigger("swordAttack");
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coins = 0;
        health = 100;
    }
}