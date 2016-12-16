using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using JumpToTower.Collectables;
using JumpToTower.Player;

namespace JumpToTower.Managers{
    public class GameManager : MonoBehaviour{

        public delegate void StartActivity();
        public static event StartActivity OnStartActivity;

        public delegate void GoalComplete();
        public static event GoalComplete OnGoalComplete;

        public delegate void EndGame();
        public static event EndGame OnEndGame;

        public delegate void ResetCoin();
        public static event ResetCoin OnResetCoin;

        [SerializeField]
        private List<Common.LEVEL> levelSequece;
        
        
        [SerializeField]
        private List<LevelModule> levels;
        [SerializeField]
        private Transform obstacles;

        [SerializeField]
        Vector3 spawnPoint = new Vector3(2.31f, -3.39f, 0f);
        [SerializeField]
        PlayerController playerPrefab;
        PlayerController currentPlayer;

        Common.LEVEL currentLevel;
        List<GoalModule> currentGoals;

        private static GameManager instance;

        public static GameManager Instance {
            get {
                return instance;
            }
        }

        void Start() {
            instance = this;
            DefineLevel();
            ConstructLevel();

            CoinData.OnCoinCollected += ActivyCoinParticle;
        }

        void OnDestroy() {
            CoinData.OnCoinCollected -= ActivyCoinParticle;
        }

        void Update() {
            if (Input.GetButtonDown("start")) {
                if (OnStartActivity != null) OnStartActivity();
            }
        }

        void DefineLevel() {
            Common.DestroyChildren(obstacles);
            NextLevel();
            InstantiatePlayer();
        }

        

        void InstantiatePlayer() {
            if (currentPlayer != null) DestroyObject(currentPlayer.gameObject);
            currentPlayer = Instantiate(playerPrefab, spawnPoint, Quaternion.identity) as PlayerController;
        }

        void ConstructLevel() {
            LevelModule currentLevelModule = levels.Find(x => x.Level.Equals(currentLevel));

            currentLevelModule.SetDataBlocks(obstacles);
            currentLevelModule.SetDataCoins(obstacles);
            currentGoals = Common.Clone(currentLevelModule.Goals);

            if (OnResetCoin != null) OnResetCoin();
        }

        void NextLevel() {
            currentLevel = levelSequece[0];
            levelSequece.RemoveAt(0);
        }

        public void DefineNextLevel() {
            DefineLevel();
            if (currentLevel == Common.LEVEL.endGame) {
                if (OnEndGame != null) OnEndGame();
            } else {
                ConstructLevel();
            }
        }

        void ActivyCoinParticle(GoalModule.GoalType type, float amount) {
            var currentGoal = currentGoals.Find(x => x.Type == type);
            currentGoal.Mount = -amount;   
                     
            if (currentGoals.FindAll(x => x.Mount > 0).Count == 0) {
                if(OnGoalComplete != null) OnGoalComplete();
            }
        }

    }
}
