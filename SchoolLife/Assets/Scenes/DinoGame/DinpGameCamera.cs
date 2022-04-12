using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinpGameCamera : MonoBehaviour
{
    private Transform playerTransform;
    public float cameraOffSetValue;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = playerTransform.position.x;
        cameraPosition.x += cameraOffSetValue;
        transform.position = cameraPosition;
    }
}
