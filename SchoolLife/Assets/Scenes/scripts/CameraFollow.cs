using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Func<Vector3> GetCameraFollowPositionFunc;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    void Update()
    {
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;
        cameraFollowPosition.y = transform.position.y;
        transform.position = cameraFollowPosition;

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            transform.position.y,
            transform.position.z
        );
    }
}
