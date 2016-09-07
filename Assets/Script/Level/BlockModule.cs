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
	private Vector3 position;
    #endregion Unity Fields

    // Use this for initialization
    public void SetData (Transform obstacles) {
		GameObject block = (GameObject) Object.Instantiate (prefab, position, Quaternion.identity);
        Debug.Log(block);
		block.GetComponent<BlocksController>().Speed = speed;
		block.transform.SetParent (obstacles);
	}

}
