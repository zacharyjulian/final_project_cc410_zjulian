// Copyright (c) Zachary Julian. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coin class. Inherited from the CollectibleItem class.
/// </summary>
public class Coin : CollectibleItem
{
    /// <summary>
    /// Gives the player their coin object and destroys the coin.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            other.GetComponent<PlayerController>().coins += 1;
            Destroy(this.gameObject);
        }
    }
}
