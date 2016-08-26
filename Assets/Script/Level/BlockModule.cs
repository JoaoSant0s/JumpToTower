using UnityEngine;
using System.Collections;
using JumpToTower.Fields;

public class BlockModule : ScriptableObject {

	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private float speed;
	[SerializeField]
	private Vector3 position;

	// Use this for initialization
	public void SetData (Transform obstacles) {
		GameObject block = (GameObject) Instantiate (prefab, position, Quaternion.identity);
		block.GetComponent<BlocksController>().Speed = speed;
		block.transform.SetParent (obstacles);

	}

}
