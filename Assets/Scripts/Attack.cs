using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;
    public float DistanceToAttack = 0.5f;
    [SerializeField] Animator _animator;

    bool _attack;

    private void Update() {

        if (_attack == false) {
            Collider[] allColliders = Physics.OverlapSphere(transform.position, DistanceToAttack);
            for (int i = 0; i < allColliders.Length; i++) {
                if (allColliders[i].TryGetComponent(out TreeCollider treeCollider)) {
                    StartAttack();
                    break;
                }
            }
        }
    }

    public void StopAttack() {
        _attack = false;
    }

    public void DoAttack() {
        Collider[] allColliders = Physics.OverlapSphere(transform.position, DistanceToAttack);
        for (int i = 0; i < allColliders.Length; i++) {
            if (allColliders[i].TryGetComponent(out TreeCollider treeCollider)) {
                treeCollider.Resources.TakeHit(1);
            }
        }
    }

    void StartAttack() {
        _animator.SetTrigger("Attack");
        _attack = true;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green * 0.8f;
        Gizmos.DrawWireSphere(transform.position, DistanceToAttack);
    }


    //#if UNITY_EDITOR
    //    // рисуем круги атаки
    //    private void OnDrawGizmosSelected() {
    //        Handles.color = Color.red;
    //        Handles.DrawWireDisc(transform.position, Vector3.up, DistanceToAttack);
    //    }
    //#endif
}
