using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JumpToTower.Managers;
using UnityEngine.SceneManagement;

namespace JumpToTower.Managers { 
    public class StartController : MonoBehaviour {

        private bool activePanel = false;

        [SerializeField]
        GameObject panelStart;

        [SerializeField]
        Button buttonReturnMenu;

        void Start () {
            GameManager.OnStartActivity += ActivePanelStart;

            buttonReturnMenu.onClick.AddListener(ReturnMenu);
            activePanel = false;
        }
	
	    void OnDestroy () {
            GameManager.OnStartActivity -= ActivePanelStart;
        }

        void ReturnMenu() {
            Common.TimeZone(false);
            SceneManager.LoadScene("Menu");
        }


        void ActivePanelStart() {
            activePanel = !activePanel;
            Common.TimeZone(activePanel);
            panelStart.SetActive(activePanel);
        }
    }
}