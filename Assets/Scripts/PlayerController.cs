using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;

    private Vector3 firstClickPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            firstClickPosition = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 moveDirestion = (Quaternion.Euler(90, 0, 0) * (Input.mousePosition - firstClickPosition)).normalized;
            rigidbody.MovePosition(transform.position + moveDirestion * speed);
        }
    }
}
