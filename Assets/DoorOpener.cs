using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform door;
    public Vector3 openRotation;
    public Vector3 closedRotation;

    private bool _isOpen;
    
    private void OnTriggerEnter(Collider col)
    {
        _isOpen = true;
    }
    private void OnTriggerExit(Collider col)
    {
        _isOpen = false;
    }

    private void Update()
    {
        if (_isOpen)
        {
            door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, Quaternion.Euler(openRotation), Time.deltaTime*0.5f);
        }
        else
        {
            door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, Quaternion.Euler(closedRotation), Time.deltaTime*0.1f);
        }
    }
}
