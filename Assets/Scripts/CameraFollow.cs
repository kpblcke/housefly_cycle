using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(0 + offset.x, 0 + offset.y, target.position.z + offset.z);
        transform.position = newPosition;
    }
}
