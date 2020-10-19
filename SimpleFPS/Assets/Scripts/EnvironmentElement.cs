using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentElement : MonoBehaviour
{
    private readonly Color32 _defaultColor = new Color32(152, 152, 152, 255);

    public void PaintToDefault()
    {
        GetComponent<MeshRenderer>().material.color = _defaultColor;
    }
}
