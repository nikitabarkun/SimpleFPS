using UnityEngine;

public class Mirror : MonoBehaviour
{
    private Renderer _renderer;
    private Camera _camera;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _camera = GetComponentInChildren<Camera>();

        //R8 просто выглядит круто :)
        var texture = new RenderTexture(256, 256, 16, RenderTextureFormat.R8);
        texture.Create();

        _renderer.material.SetTexture("_MainTex", texture);

        _camera.targetTexture = texture;
    }
}
