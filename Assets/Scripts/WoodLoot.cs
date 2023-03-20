using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLoot : MonoBehaviour
{

    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _timeSelectionResources = 1f;
    [SerializeField] Collider _collider;

    public void SetVelocity(Vector3 value) {
        _rigidbody.velocity = value;
        StartCoroutine(LifePrecess());
    }

    IEnumerator LifePrecess() {

        yield return new WaitForSeconds(_timeSelectionResources * Random.value * 0.3f);

        _rigidbody.isKinematic = true;
        _collider.enabled = false;

        Vector3 startPosition = transform.position;
        for (float t = 0; t < 1f; t += Time.deltaTime * 3f) {
            transform.position = Vector3.Lerp(startPosition, Goods.Instance.transform.position, t);
            yield return null;
        }
        Goods.Instance.AddOne();
        Destroy(gameObject);
    }
}
