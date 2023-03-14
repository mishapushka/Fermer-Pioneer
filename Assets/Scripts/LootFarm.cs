using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootFarm : MonoBehaviour
{

    [SerializeField] int _health = 5;
    private int _maxHealth;

    public GameObject HealthbarPrefab;
    private HealthBar _healthBar;

    private void Start() {
        _maxHealth = _health;
        GameObject healthBar = Instantiate(HealthbarPrefab);
        _healthBar = healthBar.GetComponent<HealthBar>();
        _healthBar.Setup(transform);
    }

    public void TakeHit(int damageValue) {
        _health -= damageValue;
        //transform.localScale *= 0.9f;
        _healthBar.SetHealth(_health, _maxHealth);
        if (_health <= 0) {
            //Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (_healthBar) {
            Destroy(_healthBar.gameObject);
        }
    }
}
