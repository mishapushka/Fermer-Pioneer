using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotating : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    void Update() {
        if (_rigidbody.velocity != Vector3.zero) {

            Vector3 velocityXZ = _rigidbody.velocity;
            velocityXZ.y = 0;

            Quaternion targetRotatin = Quaternion.LookRotation(velocityXZ);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotatin, Time.deltaTime * 25f);
        }
    }
}
