using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JumpToTower.Collectables;
using JumpToTower.Managers;
using JumpToTower.Level;

namespace JumpToTower.UI {
    public class UIController : MonoBehaviour {

        [SerializeField]
        private Text cointText;

        private string coinBaseText = "Colected coins {0}";
        private float mountCoin = 0;

        void Start() {
            cointText.text = string.Format(coinBaseText, mountCoin);
            CoinData.OnCoinCollected += ChangeCoinText;
            GameManager.OnResetCoin += ResetCoinText;
        }

        void OnDestroy() {
            CoinData.OnCoinCollected -= ChangeCoinText;
            GameManager.OnResetCoin -= ResetCoinText;
        }

        private void ChangeCoinText (GoalModule.GoalType type, float amount) {
            mountCoin += amount;
            cointText.text = string.Format(coinBaseText, mountCoin);
        }

        private void ResetCoinText() {
            mountCoin = 0;
            cointText.text = string.Format(coinBaseText, mountCoin);
        }

    }
}
