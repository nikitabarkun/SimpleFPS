using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentElement : MonoBehaviour
{
    private Color32 _defaultColor;

    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _defaultColor = _renderer.material.color;
    }

    public void PaintToDefault()
    {
        _renderer.material.color = _defaultColor;
    }
}
