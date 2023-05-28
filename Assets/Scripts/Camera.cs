using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 0.1f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if (target == null) return;

        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, speed);
    }
}
