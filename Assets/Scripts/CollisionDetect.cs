using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] private GameObject thePlayer;     // Reference to the player
    [SerializeField] private GameObject playerAnim;    // Reference to the player's Animator
    [SerializeField] private GameObject retryUIPanel;  // Reference to the retry UI panel

    void OnTriggerEnter(Collider other)
    {
        // Disable player movement
        thePlayer.GetComponent<PlayerMovement>().enabled = false;

        // Play the stumble animation
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards");

        // Show the retry UI
        retryUIPanel.SetActive(true);
    }
}
