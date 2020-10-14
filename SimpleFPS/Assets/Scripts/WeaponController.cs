using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Zoom()
    {
        _animator.SetBool("isZoomed", true);
    }

    public void Unzoom()
    {
        _animator.SetBool("isZoomed", false);
    }
}
