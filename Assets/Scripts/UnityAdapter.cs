
using UnityEngine;
using Zenject;

public class UnityAdapter : MonoBehaviour, IEnvironmentAdapter
{

    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _character;
    [SerializeField] private Animator _characterAnimator;


    [Inject] private Startup _startup;
    
    public Vector3 LastClickPosition { get; set; }
    
    void Start()
    {   
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

    public Vector3 GetCameraPosition()
    {
        return _camera.transform.position;
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
    
    public Vector3 GetCharacterPosition()
    {
        return _character.transform.position;
    }
    
    public void SetCharacterMoveForward()
    {
        _characterAnimator.SetBool("Walk", true);
    }
    
    public void StopCharacter()
    {
        _characterAnimator.SetBool("Walk", false);
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
