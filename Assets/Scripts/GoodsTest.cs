using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsTest : MonoBehaviour
{

    [SerializeField] Goods _goods;

    private void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            _goods.AddOne();
        } 

        if (Input.GetKey(KeyCode.DownArrow)) {
            _goods.RemoveOne();
        }
    }
}
