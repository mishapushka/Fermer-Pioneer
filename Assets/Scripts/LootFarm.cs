using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootFarm : MonoBehaviour
{

    [SerializeField] int _health = 5;
    
    public GameObject HealthbarPrefab;
    private HealthBar _healthBar;

    public void TakeHit() {
        _health--;
        if (_health <= 0) {
            transform.localScale *= 0.9f;
            Die();
        }
    }

    void Die() {

    }
}
