using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnvironmentAdapter
{
    Vector3 LastClickPosition { get; set; }
    
    Vector3 GetCameraPosition();
    Vector3 GetCameraEulerAngles();
    void SetCameraPosition(Vector3 position);
    
    Vector3 GetCharacterPosition();
    void SetCharacterLookAt(Vector3 lookAt);
    void SetCharacterMoveForward();
    void StopCharacter();

    public void SetDoorAngle(int id, Vector3 eulerAngle);
    public List<DoorInfo> GetDoorsInfo();


}
