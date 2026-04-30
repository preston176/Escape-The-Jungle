using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioClip coinClip;

    void OnTriggerEnter(Collider other)
    {
        if (coinClip != null)
        {
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
        }
        MasterInfo.coinCount += 1;
        this.gameObject.SetActive(false);
    }

}
