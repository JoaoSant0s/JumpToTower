using UnityEngine;
using System.Collections;


namespace JumpToTower.Collectables {
    public class CoinController : MonoBehaviour {

        public delegate void CoinCollected(Transform position);

        public static event CoinCollected OnCoinCollected;

        private bool isActivy;

        void Start() {
            isActivy = true;
        }

        void OnTriggerEnter(Collider other) {
            if (!Common.IsPlayer(other)) return;

            if (!isActivy) return;

            isActivy = false;
            OnCoinCollected(transform);

            StartCoroutine(DestroyObject());
        }

        IEnumerator DestroyObject() {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }

        
    }
}
