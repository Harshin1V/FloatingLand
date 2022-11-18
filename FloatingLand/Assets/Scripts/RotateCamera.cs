using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    [SerializeField] private float speed = 20;
    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up, Time.deltaTime * -Input.GetAxis("Horizontal") * speed);
    }
}
