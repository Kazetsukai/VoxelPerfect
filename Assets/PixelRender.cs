using UnityEngine;
using System.Collections;

public class PixelRender : MonoBehaviour
{
    public RenderTexture Texture;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(Texture, dest);
    }
}
