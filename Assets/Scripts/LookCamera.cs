using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    public Transform Target;

    void Update() {
        if (Target) {
            transform.position = Target.position;
        }
    }
}
