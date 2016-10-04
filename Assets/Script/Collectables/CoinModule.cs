using UnityEngine;
using System.Collections;
using JumpToTower.Collectables;

    [System.Serializable]
public class CoinModule {
    #region Unity Fields
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private float mount;
    [SerializeField]
    private int id;
    #endregion Unity Fields

    public void SetData(Transform obstacles) {
        GameObject coin = (GameObject) Object.Instantiate(prefab, position, Quaternion.identity);

        coin.GetComponent<CoinData>().Mount = mount;
        coin.GetComponent<CoinData>().name = string.Format("Coin: {0}", id);
        coin.transform.SetParent(obstacles);
    }
}

