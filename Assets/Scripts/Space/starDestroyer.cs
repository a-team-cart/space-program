using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starDestroyer : MonoBehaviour
{
    // Destroy a star when it crosses the trigger --------------------------
    private void OnTriggerEnter(Collider col)
    {
        // Check if the game object is a star
        if (col.gameObject.tag == "Stars")
        {
            // Destroy it if so
            Destroy(col.gameObject);
        }
    }
}
