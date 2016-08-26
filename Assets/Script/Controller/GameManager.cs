﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	[SerializeField]
	private Common.LEVEL currentlevel;
	[SerializeField]
	private List<LevelModule> levels;
	[SerializeField]
	private Transform obstacles;

	// Use this for initialization
	void Start () {
		LevelModule currentLevel = levels.Find (x => x.Level.Equals (currentlevel));
		currentLevel.SetDataBlocks(obstacles);
	}

}
