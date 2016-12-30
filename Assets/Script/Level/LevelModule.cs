using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JumpToTower.Collectables;
namespace JumpToTower.Level {
    [System.Serializable]
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

        [Header("Goals")]
        [SerializeField]
        private List<GoalModule> goals;


        public Common.LEVEL Level {
            get {
                return level;
            }
        }

        public List<BlockModule> Blocks {
            get {
                return blocks;
            }
        }

        public List<CoinModule> Coins {
            get {
                return coins;
            }
        }

        public List<GoalModule> Goals {
            get {
                return goals;
            }
        }

        public void SetDataBlocks(Transform obstacles) {
            foreach (var block in blocks) {
                block.SetData(obstacles);
            }
        }

        public void SetDataCoins(Transform obstacles) {
            foreach (var coin in coins) {
                coin.SetData(obstacles);
            }
        }
    }
}