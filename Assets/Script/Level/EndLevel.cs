using UnityEngine;
using System.Collections;
using JumpToTower.Fields;
using JumpToTower.Managers;
namespace JumpToTower.Level {
    public class EndLevel : MonoBehaviour {

        void Start() {
            AltarController.OnEndGame += EndLEvel;
        }

        void OnDestroy() {
            AltarController.OnEndGame -= EndLEvel;
        }

        void EndLEvel() {
            GameManager.Instance.DefineNextLevel();
        }
    }
}
