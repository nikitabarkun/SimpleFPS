using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnvironmentElement))]
public class EnvironmentElementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Paint to default"))
        {
            var environmentElement = (EnvironmentElement)target;
            environmentElement.PaintToDefault();
        }
    }
}
