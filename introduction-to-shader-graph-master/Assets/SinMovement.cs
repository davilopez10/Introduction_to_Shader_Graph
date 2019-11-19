using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(0, Mathf.Sin(Time.time * 2f) * 0.1f * Time.deltaTime, 0);
  }
}
