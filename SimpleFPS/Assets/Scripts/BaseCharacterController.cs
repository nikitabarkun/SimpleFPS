using System;
using System.IO;
using Player;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    private readonly int IS_MOVING = Animator.StringToHash("isMoving");

    [SerializeField]
    private KeyCode forwardKey = KeyCode.W;
    [SerializeField]
    private KeyCode backKey = KeyCode.S;
    [SerializeField]
    private KeyCode leftKey = KeyCode.A;
    [SerializeField]
    private KeyCode rightKey = KeyCode.D;

    [SerializeField]
    private PlayerInfoData characterInfo;
    
    private Transform _transform;
    private Transform _cameraTransform;

    private Animator _animator;

    private float _previousY;
    private bool _isMoving = false;

    private void Awake()
    {
        _transform = transform;
        _cameraTransform = GetComponentInChildren<Camera>().transform;

        _animator = GetComponent<Animator>();

        _previousY = _transform.position.y;
    }

    private void Update()
    {
        Move();
    }

    public void ApplyNewInfo(PlayerInfo newInfo)
    {
        characterInfo.Health = newInfo.health;
        characterInfo.Speed = newInfo.speed;
        characterInfo.FullName = newInfo.fullName;
        var textureBase64 = Convert.FromBase64String(newInfo.base64Texture);

        var texture = new Texture2D(128, 128);
        texture.LoadImage(textureBase64);
        characterInfo.Texture = texture;
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = texture;
    }

    private void Move()
    {
        _isMoving = false;

        if (Input.GetKey(forwardKey))
        {
            _transform.position += _cameraTransform.forward * Time.deltaTime;
            _isMoving = true;
        }

        if (Input.GetKey(backKey))
        {
            _transform.position -= _cameraTransform.forward * Time.deltaTime;
            _isMoving = true;
        }

        if (Input.GetKey(leftKey))
        {
            _transform.position -= _cameraTransform.right * Time.deltaTime;
            _isMoving = true;
        }

        if (Input.GetKey(rightKey))
        {
            _transform.position += _cameraTransform.right * Time.deltaTime;
            _isMoving = true;
        }

        _animator.SetBool(IS_MOVING, _isMoving);

        _transform.position = new Vector3(_transform.position.x, _previousY, _transform.position.z);
    }
}
