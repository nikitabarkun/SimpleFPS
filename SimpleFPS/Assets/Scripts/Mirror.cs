using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    private Renderer _renderer;
    private Camera _camera;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _camera = GetComponentInChildren<Camera>();

        var texture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        texture.Create();

        _renderer.material.SetTexture("_MainTex", texture);

        _camera.targetTexture = texture;
    }
}
