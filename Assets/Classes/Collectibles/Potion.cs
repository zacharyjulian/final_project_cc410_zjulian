// Copyright (c) Zachary Julian. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Potion class.
/// </summary>
public class Potion : MonoBehaviour
{
    /// <summary>
    /// Gives the player their potion object.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            other.GetComponent<PlayerController>().health += 50;
            Destroy(this.gameObject);
        }
    }
}
