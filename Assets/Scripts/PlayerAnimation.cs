using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] Animator _animator;

    void Update()
    {
        _animator.SetBool("Idle", true);
        if(Input.GetKeyDown(KeyCode.Space)) {
            _animator.SetTrigger("Attack");
        }
    }
}
