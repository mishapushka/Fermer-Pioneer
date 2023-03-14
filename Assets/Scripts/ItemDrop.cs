using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody _itemRigidbody;
    public float DropForce = 20;

    void Start()
    {
        _itemRigidbody = GetComponent<Rigidbody>();
        _itemRigidbody.AddForce(Vector3.up * DropForce, ForceMode.Impulse);
    }
}
