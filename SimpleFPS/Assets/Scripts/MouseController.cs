using UnityEngine;

public class MouseController : MonoBehaviour
{
    private const float SENSIVITY = 3F;
    private const float MAX_ANGLE_DEVIATION = 30F;

    private Vector2 _relativeRotation = Vector2.zero;

    private WeaponController _weaponController;

    private Transform _transform;
    private Transform _cameraTransform;

    private void Awake()
    {
        _weaponController = GetComponent<WeaponController>();

        _transform = transform;
        _cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        Rotate();

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _weaponController.SetAlternativeAiming(Input.GetKey(KeyCode.LeftShift));

            _weaponController.Aim();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _weaponController.Unaim();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _weaponController.Shoot();
        }
    }

    private void Rotate()
    {
        _relativeRotation.x += -Input.GetAxis("Mouse Y");
        _relativeRotation.x = Mathf.Clamp(_relativeRotation.x, -MAX_ANGLE_DEVIATION, MAX_ANGLE_DEVIATION);

        _relativeRotation.y += Input.GetAxis("Mouse X");

        _transform.eulerAngles = new Vector2(0, _relativeRotation.y) * SENSIVITY;
        _cameraTransform.localRotation = Quaternion.Euler(_relativeRotation.x * SENSIVITY, 0, 0);
    }
}
