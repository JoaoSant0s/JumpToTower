using UnityEngine;
using System.Collections;
using JumpToTower.Fields;

[System.Serializable]
public class BlockModule {
    #region Unity Fields
    [SerializeField]
	private GameObject prefab;
	[SerializeField]
	private float speed;
    [SerializeField]
    private int id;
    [SerializeField]
	private Vector3 position;
    #endregion Unity Fields

    public void SetData (Transform obstacles) {
		GameObject block = (GameObject) Object.Instantiate (prefab, position, Quaternion.identity);
        
		block.GetComponent<BlockData>().Speed = speed;
        block.GetComponent<BlockData>().name = string.Format("Block: {0}", id);
        block.transform.SetParent (obstacles);
	}

}
