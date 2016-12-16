using UnityEngine;
using System.Collections;


namespace JumpToTower.Collectables {
    public class CoinData : MonoBehaviour {

        public delegate void CoinCollected(GoalModule.GoalType type, float amount);
        public delegate void CoinPosition(Vector3 position);

        public static event CoinCollected OnCoinCollected;
        public static event CoinPosition OnCoinPosition;

        private bool isActivy;
        private const float waitDestroyTime = 1f;

        [SerializeField]
        float mount = 1;

        void Start() {
            isActivy = true;
        }

        public float Mount {
            get {
                return mount;
            }
            set {
                mount = value;
            }
        }

        void OnTriggerEnter(Collider other) {
            if (!Common.IsPlayer(other)) return;

            if (!isActivy) return;

            isActivy = false;

            OnCoinPosition(transform.position);
            OnCoinCollected(GoalModule.GoalType.coin, Mount);
            
            DestroyObject();
        }

        void DestroyObject() {
            Destroy(gameObject);
        }
    }
}
