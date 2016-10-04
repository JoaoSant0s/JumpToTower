using UnityEngine;
using System.Collections;


namespace JumpToTower.Collectables {
    public class CoinData : MonoBehaviour {

        public delegate void CoinCollected(CoinData coinData);

        public static event CoinCollected OnCoinCollected;

        private bool isActivy;

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
            OnCoinCollected(this);

            StartCoroutine(DestroyObject());
        }

        IEnumerator DestroyObject() {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }

        
    }
}
