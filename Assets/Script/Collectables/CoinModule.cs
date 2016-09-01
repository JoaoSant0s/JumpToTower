using UnityEngine;
using System.Collections;


public class CoinModule : ScriptableObject {

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Vector3 position;

    public void SetData(Transform obstacles) {
        GameObject block = (GameObject)Instantiate(prefab, position, Quaternion.identity);
        block.transform.SetParent(obstacles);
    }
}

