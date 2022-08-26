using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnvironmentAdapter
{
    Vector3 LastClickPosition { get; set; }
    Vector3 GetCameraPosition();
    void SetCameraPosition(Vector3 position);
    void SetCameraRotation(Quaternion rotation);
    void SetCharacterLookAt(Vector3 lookAt);
    Vector3 GetCharacterPosition();
    void SetCharacterMoveForward();
    void StopCharacter();
}
