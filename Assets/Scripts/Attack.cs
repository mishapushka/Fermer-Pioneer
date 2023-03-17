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
    [SerializeField] TrailRenderer _trailRenderer;
    [SerializeField] ParticleSystem _clawAttackEffect;
    public float _speedEffect = 0.5f;

    bool _attack;

    private void Start() {
        DisableTrail();
    }

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

    public void EnableTrail() {
       _trailRenderer.enabled = true;
    }

    public void DisableTrail() {
        _trailRenderer.enabled = false;
    }

    //[System.Obsolete]
    //public void AttackEffectOn() {
    //    _clawAttackEffect.Play();
    //    _clawAttackEffect.startSpeed = 5f;
    //}

    //public void AttackEffectOff() {
    //    _clawAttackEffect.Stop();
    //}

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

    //private void ClawAttack() {
    //    Instantiate(_clawAttackEffect, transform.position, Quaternion.identity);
    //}

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
