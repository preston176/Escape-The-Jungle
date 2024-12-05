using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnim;
    void OnTriggerEnter(Collider other)
    {
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards");

    }

}
