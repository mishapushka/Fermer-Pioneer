using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _speed;
    [SerializeField] PlayerControllerCustomPerson _playerControll;

    private void FixedUpdate() {
        _rigidbody.velocity = new Vector3(_playerControll.InputValue.x, 0f, _playerControll.InputValue.y) * _speed;
    }
}
