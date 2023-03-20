using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDieEffect : MonoBehaviour
{

    [SerializeField] WoodLoot[] _woodLoot;

    [SerializeField] float _maxSpeedY = 6f;
    [SerializeField] float _maxSpeedXZ = 3f;

    private void Start() {
        for (int i = 0; i < _woodLoot.Length; i++) {

            Vector2 side = Random.insideUnitCircle * _maxSpeedXZ;
            float up = Random.value * _maxSpeedY;

            Vector3 velocity = new Vector3(side.x, up, side.y);

            _woodLoot[i].SetVelocity(velocity);
        }
    }
}
