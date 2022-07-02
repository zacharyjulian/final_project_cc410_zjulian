// Copyright (c) Zachary Julian. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Chest class.
/// </summary>
public class Chest : Enemy
{
    public GameObject reward;

    /// <summary>
    /// Constructor for a chest object. Changes the health to 9.
    /// </summary>
    public Chest()
    {
        this.Health = 9;
    }

    /// <summary>
    /// Removes the chest from the game and spawns a reward.
    /// </summary>
    public override void RemoveEnemy()
    {
        Destroy(this.gameObject);
        print("chest broke");
        GameObject rewardObj = Instantiate(this.reward);
        rewardObj.transform.position = this.transform.position;
    }
}
