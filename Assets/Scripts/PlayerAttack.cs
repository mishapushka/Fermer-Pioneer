using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public enum BuildingState {
    Idle,
    Walking,
    Attack
}

public class PlayerAttack : MonoBehaviour
{
    public BuildingState CurrentState;
    public float DistanceToAttack = 1f;
    public NavMeshAgent NavMeshAgent;

    public float AttackPeriod = 1f;
    private float _timer;

    public Building TargetBuilding;

    void Update() {

        Collider[] allColliders = Physics.OverlapSphere(transform.position, AttackPeriod);
        for (int i = 0; i < allColliders.Length; i++) {

            if (allColliders[i].TryGetComponent(out TreeCollider treeCollider)) {
                SetState(BuildingState.Attack);
            }
        }
    }

    public void SetState(BuildingState enemyState) {
        CurrentState = enemyState;
        if (CurrentState == BuildingState.Idle) {

        } else if (CurrentState == BuildingState.Walking) {
   
            if (TargetBuilding) {
                NavMeshAgent.SetDestination(TargetBuilding.transform.position);
            } else {
                SetState(BuildingState.Idle);
            }
        } else if (CurrentState == BuildingState.Attack) {
            _timer = 0;
        }
    }

#if UNITY_EDITOR
    // рисуем круги атаки
    private void OnDrawGizmosSelected() {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, DistanceToAttack);
    }
#endif
}
