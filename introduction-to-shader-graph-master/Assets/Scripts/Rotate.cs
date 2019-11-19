using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  public Vector3 rotationVector;

  private Transform cacheTransform;

  private void Awake()
  {
    cacheTransform = transform;
  }

  private void Update()
  {
    cacheTransform.Rotate(rotationVector * Time.deltaTime);
  }
}
