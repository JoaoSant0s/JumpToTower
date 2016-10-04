using UnityEngine;
using System.Collections;
using JumpToTower.Collectables;

namespace JumpToTower.Managers {
    public class ParticleSystemController : MonoBehaviour {

        [SerializeField]
        private GameObject particlePrefab;
        // Use this for initialization
        void Start() {
            CoinData.OnCoinCollected += ActivyCoinParticle;
        }

        void OnDestroy() {
            CoinData.OnCoinCollected -= ActivyCoinParticle;
        }

        void ActivyCoinParticle(CoinData parent) {
            var particle = Instantiate(particlePrefab, parent.transform.position, Quaternion.identity) as GameObject;

            particle.transform.SetParent(parent.transform);
            particle.GetComponentInChildren<ParticleSystem>().Play();  
        }
    }
}
