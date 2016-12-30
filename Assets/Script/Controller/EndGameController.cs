using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JumpToTower.Managers;
using UnityEngine.SceneManagement;

namespace JumpToTower.Managers {
    public class EndGameController : MonoBehaviour {

        [SerializeField]
        GameObject endFeedback;

        [SerializeField]
        Button buttonReturnMenu;

        void Start() {
            GameManager.OnEndGame += EndGameFeedback;

            buttonReturnMenu.onClick.AddListener(ReturnMenu);
        }

        void ReturnMenu() {
            Common.TimeZone(false);
            SceneManager.LoadScene("Menu");
        }

        void OnDestroy() {
            GameManager.OnEndGame -= EndGameFeedback;

        }

        void EndGameFeedback() {
            Common.TimeZone(true);
            endFeedback.SetActive(true);
        }
    }
}
