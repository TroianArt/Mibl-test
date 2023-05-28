using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;

    private Vector3 firstClickPosition;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstClickPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = Input.mousePosition - firstClickPosition;
            Vector3 move = new Vector3(difference.x, transform.position.y, difference.y).normalized;

            transform.LookAt(transform.position + move);
            rigidbody.MovePosition(transform.position + move * Time.deltaTime * speed);
        }
    }
}
