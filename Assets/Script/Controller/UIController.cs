using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JumpToTower.Collectables;

    namespace JumpToTower.UI {
    public class UIController : MonoBehaviour {

        [SerializeField]
        private Text cointText;

        private string coinBaseText = "Colected coins {0}";
        private float mountCoin = 0;

        void Start() {
            cointText.text = string.Format(coinBaseText, mountCoin);
            CoinData.OnCoinCollected += ChangeCoinText;
        }

        void OnDestroy() {
            CoinData.OnCoinCollected -= ChangeCoinText;
        }

        private void ChangeCoinText (GoalModule.GoalType type, float amount) {
            mountCoin += amount;
            cointText.text = string.Format(coinBaseText, mountCoin);
        }

    }
}
