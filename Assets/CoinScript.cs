// Copyright (c) Zachary Julian. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// CoinScript class.
/// </summary>
public class CoinScript : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI coinText;

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        this.coinText.text = "Coins : " + this.player.GetComponent<PlayerController>().coins;
    }
}
