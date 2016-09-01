using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JumpToTower.Collectables;

public class LevelModule : ScriptableObject {

    [Header("Level Number")]
    [SerializeField]
	private Common.LEVEL level;

    [Header("Blocks of Level")]
    [SerializeField]
	private List<BlockModule> blocks;

    [Header("Coins of Level")]
    [SerializeField]
    private List<CoinModule> coins;


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

    public List<CoinModule> Coins {
        get {
            return coins;
        }
    }

    public void SetDataBlocks(Transform obstacles){
		foreach (var block in blocks) {
			block.SetData (obstacles);
		}
	}

    public void SetDataCoins(Transform obstacles) {
        foreach (var coin in coins) {
            coin.SetData(obstacles);
        }
    }
		
}
