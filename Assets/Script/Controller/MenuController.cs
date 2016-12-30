using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using JumpToTower.Managers;

namespace JumpToTower.UI {
    public class MenuController : MonoBehaviour {

        public delegate void SettingsActivity();
        public static event SettingsActivity OnSettingsActivity;

        [Space(5)]
        [SerializeField]
        GameObject menuPanel;

        [Header("Buttons list")]
        [Space(10)]
        [SerializeField]
        Button buttonPlay;
        [SerializeField]
        Button buttonStteings;



        void Start() {
            SettingsController.OnMenuActivity += MenuActivity;

            buttonPlay.onClick.AddListener(ActionPlay);
            buttonStteings.onClick.AddListener(ActionSettings);
        }

        void OnDestroy() {
            SettingsController.OnMenuActivity -= MenuActivity;
        }

        void MenuActivity() {
            menuPanel.SetActive(true);
        }

        void ActionPlay() {
            SceneManager.LoadScene("Game");
        }

        void ActionSettings() {
            if (OnSettingsActivity != null) {
                menuPanel.SetActive(false);
                OnSettingsActivity();
            }
        }
    }
}

