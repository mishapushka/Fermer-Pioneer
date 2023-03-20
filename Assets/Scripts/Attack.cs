using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attack : MonoBehaviour
{
    
    public float DistanceToAttack = 0.5f;
    [SerializeField] Animator _animator;
    [SerializeField] TrailRenderer _trailRenderer;
   // [SerializeField] ParticleSystem _clawAttackEffect;
    public GameObject _clawAttackEffect;
    //bool _effect;
    //public float _speedEffect = 0.5f;

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
                    Invoke("AttackEffectOn", 0.6f);
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

    public void AttackEffectOn() {
        GameObject clone = Instantiate(_clawAttackEffect, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(clone, 3);
    }

    //public void AttackEffectOff() {
    //    //_clawAttackEffect.Stop();
    //    Destroy(_clawAttackEffect);
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
