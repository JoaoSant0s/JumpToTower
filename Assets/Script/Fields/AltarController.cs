using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JumpToTower.Managers;

namespace JumpToTower.Fields{
    public class AltarController : MonoBehaviour {

        public delegate void EndGame();
        public static event EndGame OnEndGame;

        Color finalColor = Color.green;
        Color initialColor = Color.black;
        const string CONFIRM = "confirm";

        [SerializeField]
        private GameObject textMessage;
        [SerializeField]
        private GameObject token;
   
        private bool active;

        void Start() {
            active = false;
            textMessage.SetActive(false);
            GameManager.OnGoalComplete += ActiveToken;
        }

        void OnDestroy() {
            GameManager.OnGoalComplete -= ActiveToken;
        }

        void OnTriggerEnter(Collider other) {
            if (!Common.IsPlayer(other)) return;
            if (!active) return;

            textMessage.SetActive(true);
        }


        void OnTriggerStay(Collider other) {
            if (!Common.IsPlayer(other)) return;
            if (!active) return;

            if (Input.GetButtonDown(CONFIRM)) {
                if (OnEndGame != null) OnEndGame();
                DesactiveToken();
            }
        }

        void DesactiveToken() {
            token.GetComponent<Renderer>().material.color = initialColor;
            active = false;
            textMessage.SetActive(false);
        }

        void ActiveToken() {
            token.GetComponent<Renderer>().material.color = finalColor;
            active = true;
            
        }

        void OnTriggerExit(Collider other) {
            if (!Common.IsPlayer(other)) return;
            if (!active) return;

            textMessage.SetActive(false);
        }
    }
}
