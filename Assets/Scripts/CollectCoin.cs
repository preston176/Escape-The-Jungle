using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        // print("YOOOOOO");
        coinFX.Play();
        this.gameObject.SetActive(false);

    }

}