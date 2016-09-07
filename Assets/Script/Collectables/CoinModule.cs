using UnityEngine;
using System.Collections;

[System.Serializable]
public class CoinModule {
    #region Unity Fields
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Vector3 position;
    #endregion Unity Fields

    public void SetData(Transform obstacles) {
        GameObject block = (GameObject) Object.Instantiate(prefab, position, Quaternion.identity);
        block.transform.SetParent(obstacles);
    }
}

