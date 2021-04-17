using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed = 10;

    void Start()
    {
        
    }

    
    void Update()
    {
        float RotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, RotateInput * speed * Time.deltaTime);
    }
}
