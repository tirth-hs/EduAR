using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    Vector3 movement;
    void Start()
    {
        movement = new Vector3(0,0.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(movement);
    }
}
