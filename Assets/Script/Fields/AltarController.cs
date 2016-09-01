﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace JumpToTower.Fields{
    public class AltarController : MonoBehaviour {
        [SerializeField]
        private GameObject textMessage;

        private bool active;

        void Start() {
            textMessage.SetActive(false);
        }

        void OnTriggerEnter(Collider other) {
            if (!Common.IsPlayer(other))
                return;

            textMessage.SetActive(true);
        }

        void OnTriggerExit(Collider other) {
            if (!Common.IsPlayer(other))
                return;

            textMessage.SetActive(false);
        }
    }
}
