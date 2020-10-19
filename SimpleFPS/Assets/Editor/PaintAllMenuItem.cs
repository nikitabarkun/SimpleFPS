using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaintAllMenuItem : MonoBehaviour
{
    [MenuItem("Tools/Paint all red")]
    public static void PaintAllRed()
    {
        var allRenderers = GameObject.FindObjectsOfType<MeshRenderer>();

        foreach (var renderer in allRenderers)
        {
            renderer.material.color = Color.red;
        }
    }
}
