using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    [SerializeField]
    private KeyCode forwardKey = KeyCode.W;
    [SerializeField]
    private KeyCode backKey = KeyCode.S;
    [SerializeField]
    private KeyCode leftKey = KeyCode.A;
    [SerializeField]
    private KeyCode rightKey = KeyCode.D;

    private Transform _transform;
    private Transform _cameraTransform;

    private float _previousY;

    private void Awake()
    {
        _transform = transform;
        _cameraTransform = GetComponentInChildren<Camera>().transform;

        _previousY = _transform.position.y;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(forwardKey))
        {
            _transform.position += _cameraTransform.forward * Time.deltaTime;
        }

        if (Input.GetKey(backKey))
        {
            _transform.position -= _cameraTransform.forward * Time.deltaTime;
        }

        if (Input.GetKey(leftKey))
        {
            _transform.position -= _cameraTransform.right * Time.deltaTime;
        }

        if (Input.GetKey(rightKey))
        {
            _transform.position += _cameraTransform.right * Time.deltaTime;
        }

        _transform.position = new Vector3(_transform.position.x, _previousY, _transform.position.z);
    }
}
