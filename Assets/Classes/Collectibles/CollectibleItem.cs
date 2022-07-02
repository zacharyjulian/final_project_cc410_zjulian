// Copyright (c) Zachary Julian. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CollectibleItem class.
/// </summary>
public abstract class CollectibleItem : MonoBehaviour
{
    private string itemName { get; set; }
    private string description { get; set; }
}
