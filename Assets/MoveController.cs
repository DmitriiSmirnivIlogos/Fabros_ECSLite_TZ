using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
        
        
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -1);
        }
        else  if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 1);
        }
    }
}
