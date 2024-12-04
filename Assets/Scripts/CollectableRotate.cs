using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotate : MonoBehaviour
{

    [SerializeField] int rotateSpeed = 2;
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
