using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelModule : ScriptableObject {
	
	[SerializeField]
	private Common.LEVEL level;

	[SerializeField]
	private List<BlockModule> blocks;


	public Common.LEVEL Level{
		get{ 
			return level;
		}
	}

	public List<BlockModule> Blocks{
		get{ 
			return blocks;
		}
	}

	public void SetDataBlocks(Transform obstacles){
		foreach (var block in blocks) {
			block.SetData (obstacles);
		}
	}
		
}
