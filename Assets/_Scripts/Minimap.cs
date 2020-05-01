using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform playerTransform;

    private void LateUpdate()
    {
        Vector3 newPos = playerTransform.position;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}
