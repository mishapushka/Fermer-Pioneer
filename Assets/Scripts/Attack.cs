using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] float _attackRadius = 1.5f;

    private void Update() {

        Collider[] allColliders = Physics.OverlapSphere(transform.position, _attackRadius);
        for (int i = 0; i < allColliders.Length; i++) {
            if (allColliders[i].TryGetComponent(out TreeCollider treeCollider)) {
                treeCollider.Resources.TakeHit(1);
                break;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green * 0.8f;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
