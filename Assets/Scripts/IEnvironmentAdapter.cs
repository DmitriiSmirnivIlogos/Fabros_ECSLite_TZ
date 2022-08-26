using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnvironmentAdapter
{
    void SetCameraPosition(Vector3 position);
    void SetCameraRotation(Quaternion rotation);
    void SetCharacterLookAt(Vector3 lookAt);
    void SetCharacterMoveForward();
    void StopCharacter();
}
