using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    [SerializeField] private Image stick;
    [SerializeField] private float maxDistance;

    private Vector3 basePosition;

    void Update()
    {
        if (!GameManager.instance.IsGame) return;

        if (Input.GetMouseButtonDown(0))
        {
            basePosition = Input.mousePosition;
            transform.position = basePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 stickPosition = Input.mousePosition - basePosition;
            stick.transform.localPosition = Vector3.ClampMagnitude(stickPosition, maxDistance);
        }
    }
}
