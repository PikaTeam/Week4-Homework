using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(this.rotationVector*Time.deltaTime);
    }

    public void SetRotation(Vector3 rotation)
    {
        this.rotationVector = rotation;
    }
}
