// referenced class from Mister Taft Creates video tutorial on changing scenes
// https://www.youtube.com/watch?v=wNl--exin90&t=571s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SceneChangeButton class.
/// </summary>
public class SceneChangeButton : MonoBehaviour
{
    public string sceneToLoad;

    /// <summary>
    /// Changes the scene when the player steps on the trigger.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(this.sceneToLoad);
        }
    }
}