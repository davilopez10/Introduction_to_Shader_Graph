using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurCrystal : MonoBehaviour
{
  private MeshRenderer meshRenderer;
  private const string shaderPropertyName = "_RawTexture";

  public float radius = 1f;

  private Texture2D texture;
  private Camera mainCamera;
  private Ray ray;

  private RaycastHit hitInfo;
  private Vector2? inputMouse;

  private void Awake()
  {
    meshRenderer = GetComponent<MeshRenderer>();
    mainCamera = Camera.main;

    texture = new Texture2D(512, 512, TextureFormat.RFloat, false, true);

    for (int i = 0; i < texture.height; i++)
    {
      for (int j = 0; j < texture.width; j++)
        texture.SetPixel(i, j, Color.black);
    }

    texture.Apply();

    meshRenderer.material.SetTexture(shaderPropertyName, texture);
  }

  private void OnMouseDrag()
  {
    if (inputMouse == null)
      inputMouse = Input.mousePosition;

    inputMouse = Vector2.Lerp(inputMouse.Value, Input.mousePosition, Time.deltaTime * 6f);

    ray = mainCamera.ScreenPointToRay(inputMouse.Value);

    if (Physics.Raycast(ray, out hitInfo, 100f))
    {
      int x = (int)(hitInfo.textureCoord.x * texture.width);
      int y = (int)(hitInfo.textureCoord.y * texture.height);

      texture.SetPixel(x, y, Color.red);

      for (int i = 0; i < texture.height; i++)
      {
        for (int j = 0; j < texture.width; j++)
        {
          float dist = Vector2.Distance(new Vector2(i, j), new Vector2(x, y));

          if (dist <= radius)
            texture.SetPixel(i, j, new Color(Time.timeSinceLevelLoad, 0, 0, 1));
        }
      }

      texture.Apply();
    }
  }

  private void OnMouseUp()
  {
    inputMouse = null;
  }

}