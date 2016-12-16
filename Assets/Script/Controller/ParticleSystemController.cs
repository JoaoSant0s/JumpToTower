using UnityEngine;
using System.Collections;
using JumpToTower.Collectables;

namespace JumpToTower.Managers {
    public class ParticleSystemController : MonoBehaviour {

        [SerializeField]
        private ParticleController particlePrefab;

        void Start() {
            CoinData.OnCoinPosition += ActivyCoinParticle;
        }

        void OnDestroy() {
            CoinData.OnCoinPosition -= ActivyCoinParticle;
        }

        void ActivyCoinParticle(Vector3 position) {
            var particle = Instantiate(particlePrefab, position, Quaternion.identity) as ParticleController;
            particle.PlayParticle();
        }
    }
}
