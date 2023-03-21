using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goods : MonoBehaviour
{

    [SerializeField] Transform _goodsParent;
    [SerializeField] List<Wood> _goodsLootList = new List<Wood>();
    [SerializeField] Wood _goodsLootPrefab;
    [SerializeField] float _offset;
    [Min(1)]
    [SerializeField] int _numberOfRows = 3;

    public static Goods Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    public void AddOne() {
        
       Wood newWood = Instantiate(_goodsLootPrefab, _goodsParent);
        _goodsLootList.Add(newWood);
        SetPositions();
    }

    public void RemoveOne() {
        int lastIndex = _goodsLootList.Count - 1;
        if (lastIndex >= 0) {
            Destroy(_goodsLootList[lastIndex].gameObject);
            _goodsLootList.RemoveAt(lastIndex);
        }
    }

    void SetPositions() {
        for (int i = 0; i < _goodsLootList.Count; i++) {
            
            int x = i % _numberOfRows;
            int y = i / _numberOfRows;

            _goodsLootList[i].transform.localPosition = new Vector3(x, y, 0) * _offset;
        }
    }
}
