using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private const float Sensitivity = 3F;
    private const float MaxAngleDeviation = 30F;

    private Vector2 _relativeRotation = Vector2.zero;

    private Transform _transform;
    private Transform _cameraTransform;

    protected void Awake()
    {
        _transform = transform;
        _cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _relativeRotation.x += -Input.GetAxis("Mouse Y");
        _relativeRotation.x = Mathf.Clamp(_relativeRotation.x, -MaxAngleDeviation, MaxAngleDeviation);

        _relativeRotation.y += Input.GetAxis("Mouse X");

        _transform.eulerAngles = new Vector2(0, _relativeRotation.y) * Sensitivity;
        _cameraTransform.localRotation = Quaternion.Euler(_relativeRotation.x * Sensitivity, 0, 0);
    }
}
