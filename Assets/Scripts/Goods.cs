using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goods : MonoBehaviour
{

    [SerializeField] Transform _goodsParent;
    [SerializeField] List<Wood> _goodsLootList = new List<Wood>();
    [SerializeField] Wood _goodsLootPrefab;
    [SerializeField] float _offset;

    public void AddOne() {
        
       Wood newWood = Instantiate(_goodsLootPrefab, _goodsParent);
        _goodsLootList.Add(newWood);
        SetPositions();
    }

    public void RemoveOne() {
        int lastIndex = _goodsLootList.Count - 1;
        Destroy(_goodsLootList[lastIndex].gameObject);
        _goodsLootList.RemoveAt(lastIndex);
    }

    void SetPositions() {
        for (int i = 0; i < _goodsLootList.Count; i++) {
            _goodsLootList[i].transform.localPosition = new Vector3(0f, i, 0f) * _offset;
        }
    }
}
