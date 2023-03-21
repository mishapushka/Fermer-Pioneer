using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] Animator _animator;
    public PlayerMove _joystick;

    void Update()
    {
        _animator.SetBool("Run", true);
        if(Input.GetKeyDown(KeyCode.Space)) {
            _animator.SetTrigger("Attack");
        }
    }
}
