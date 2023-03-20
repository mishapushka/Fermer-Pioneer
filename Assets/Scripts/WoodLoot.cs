using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLoot : MonoBehaviour
{

    [SerializeField] Rigidbody _rigidbody;

    public void SetVelocity(Vector3 value) {
        _rigidbody.velocity = value;
    }
}
