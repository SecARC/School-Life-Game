using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoGameGroundScript : MonoBehaviour
{
    private float lenghtOfGround;
    private float startPosition;
    public GameObject _camera;
    public float parallaxSpeed;

    void Start()
    {
        startPosition = transform.position.x;
        lenghtOfGround = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = _camera.transform.position.x * (1 - parallaxSpeed);
        float distance = _camera.transform.position.x * parallaxSpeed;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        if (temp > startPosition + lenghtOfGround)
        {
            startPosition += lenghtOfGround;
        }
    }
}
