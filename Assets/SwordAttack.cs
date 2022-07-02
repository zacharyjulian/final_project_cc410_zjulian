// referenced from Chris' Tutorials 2D Game Tutorial
// https://www.youtube.com/watch?v=7iYWpzL9GkM&t=73s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SwordAttack class.
/// </summary>
public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 3;
    Vector2 rightAttackOffset;

    /// <summary>
    /// Attacks to the right.
    /// </summary>
    public void AttackRight()
    {
        this.swordCollider.enabled = true;
        this.transform.localPosition = this.rightAttackOffset;
    }

    /// <summary>
    /// Attacks to the left.
    /// </summary>
    public void AttackLeft()
    {
        this.swordCollider.enabled = true;
        this.transform.localPosition = new Vector3(this.rightAttackOffset.x * -1, this.rightAttackOffset.y);
    }

    /// <summary>
    /// Stops an attack.
    /// </summary>
    public void StopAttack()
    {
        this.swordCollider.enabled = false;
    }

    /// <summary>
    /// Called when the game loads.
    /// </summary>
    private void Start()
    {
        this.rightAttackOffset = this.transform.localPosition;
    }

    /// <summary>
    /// Checks to see if the sword collided with the enemy, if so deals damage.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger");
        if (other.tag == "Enemy")
        {
            print("hit");

            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= this.damage;
            }
        }
    }
}
