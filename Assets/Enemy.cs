// referenced from Chris' Tutorials 2D Game Tutorial
// https://www.youtube.com/watch?v=7iYWpzL9GkM&t=73s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy class.
/// </summary>
public class Enemy : MonoBehaviour
{
    Animator animator;
    public GameObject coin;
    public float health = 1;

    /// <summary>
    /// Gets or sets the health of the enemy.
    /// </summary>
    public float Health
    {
        get
        {
            return this.health;
        }

        set
        {
            this.health = value;

            if (this.health <= 0)
            {
                this.Defeated();
            }
        }
    }

    /// <summary>
    /// Triggers the defeated property of the animation.
    /// </summary>
    public void Defeated()
    {
        this.animator.SetTrigger("Defeated");
    }

    /// <summary>
    /// Removes the enemy from the game and spawns a coin.
    /// </summary>
    public virtual void RemoveEnemy()
    {
        Destroy(gameObject);
        GameObject coinObj = Instantiate(coin);
        coinObj.transform.position = transform.position;
    }

    /// <summary>
    /// Runs when the scene is loaded.
    /// </summary>
    private void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }
}
