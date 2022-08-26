using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAdapter : MonoBehaviour, IEnvironmentAdapter
{

    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _character;
    [SerializeField] private Animator _characterAnimator;


    private Startup _startup;
    
    public Vector3 LastClickPosition { get; set; }
    
    void Start()
    {   
        _startup = new Startup();
        _startup.Init();
    }

    void Update()
    {
        _startup.Update();
    }

    void OnDestroy()
    {
        _startup.OnDestroy();
    }

    public void SetCameraPosition(Vector3 position)
    {
        _camera.transform.position = position;
    }

    public void SetCameraRotation(Quaternion rotation)
    {
        _camera.transform.rotation = rotation;
    }
    
    public void SetCharacterLookAt(Vector3 lookAt)
    {
       _character.transform.LookAt(new Vector3(lookAt.x, _character.transform.position.y, lookAt.z));
    }
    
    public void SetCharacterMoveForward()
    {
        _characterAnimator.SetBool("Walk", true);
    }
    
    public void StopCharacter()
    {
        _characterAnimator.SetBool("False", true);
    }

    private void OnMouseUp()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            LastClickPosition = hit.point;
        }
    }
}
