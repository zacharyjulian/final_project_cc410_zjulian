// Copyright (c) Zachary Julian. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// HealthScript class.
/// </summary>
public class HealthScript : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI healthText;

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        this.healthText.text = "Health : " + this.player.GetComponent<PlayerController>().health;
    }
}
