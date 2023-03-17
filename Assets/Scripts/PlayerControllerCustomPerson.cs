using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCustomPerson : MonoBehaviour {
    
    private Vector3 _startMousePosition;
    public Vector2 InputValue;

    void Update() {
        //if (InputValue.GetMouseButtonDown(0)) {
        //    _startMousePosition = InputValue.mousePosition;
        //}

        //if (InputValue.GetMouseButton(0)) {
        //    Vector3 delta = (InputValue.mousePosition - _startMousePosition) / 50f;
        //    float magnitude = delta.magnitude;
        //    float clampMagnitude = Mathf.Clamp(magnitude, 0f, 1f);

        //    Vector3 deltaNormalized = delta.normalized * clampMagnitude;
        //    InputValue = new Vector2(deltaNormalized.x, deltaNormalized.y);
        //}

        //if (InputValue.GetMouseButtonUp(0)) {
        //    InputValue = Vector2.zero;
        //}

    }
}
