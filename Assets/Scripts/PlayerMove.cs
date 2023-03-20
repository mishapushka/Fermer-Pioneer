using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] FixedJoystick _joystick;
    [SerializeField] NavMeshAgent NavMeshAgent;
    [SerializeField] float _speed;

    private void FixedUpdate() {
        NavMeshAgent.velocity = new Vector3(-_joystick.Horizontal * _speed, -NavMeshAgent.velocity.y, -_joystick.Vertical * _speed);
    }
}
