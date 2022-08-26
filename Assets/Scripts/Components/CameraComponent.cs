using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CameraComponent
{
    public Transform cameraTransform;
    public Vector3 curVelocity;
    public Vector3 offset;
    public Vector3 rotation;
    public float cameraSmoothness;
}
