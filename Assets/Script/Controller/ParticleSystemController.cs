using UnityEngine;
using System.Collections;
using JumpToTower.Collectables;

namespace JumpToTower.Managers {
    public class ParticleSystemController : MonoBehaviour {

        [SerializeField]
        private GameObject particlePrefab;
        // Use this for initialization
        void Start() {
            CoinController.OnCoinCollected += ActivyCoinParticle;
        }

        void OnDestroy() {
            CoinController.OnCoinCollected -= ActivyCoinParticle;
        }

        void ActivyCoinParticle(Transform parent) {
            var particle = Instantiate(particlePrefab, parent.position, Quaternion.identity) as GameObject;

            particle.transform.SetParent(parent);
            particle.GetComponentInChildren<ParticleSystem>().Play();  
        }
    }
}
