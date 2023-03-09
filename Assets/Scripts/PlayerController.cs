using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private NavMeshAgent NavMeshAgent;

    [SerializeField] private float _moveSpeed;

    private void FixedUpdate() {
        NavMeshAgent.velocity = new Vector3(-_joystick.Horizontal * _moveSpeed, -NavMeshAgent.velocity.y, -_joystick.Vertical * _moveSpeed);
    }
}
