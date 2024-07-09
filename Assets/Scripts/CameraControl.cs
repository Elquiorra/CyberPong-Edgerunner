using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float smoothing;
    public float rotationSmoothing;
    [SerializeField] private float rotationCar;
    public Transform player;
    public CyberController cyber;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothing);

        if (cyber.CheckIsGrounded())
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotationSmoothing);
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + rotationCar, 0));
        }
    }
}