﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace JumpToTower.Fields{
	public class AltarController : MonoBehaviour {
		[SerializeField]
		private GameObject textMessage;

		private bool active;

		void Start(){
			textMessage.SetActive (false);
		}

		bool IsPlayer(Collider player){
			return player.gameObject.tag.Equals (Common.TAGS.Player.ToString ());
		}
			
		void OnTriggerEnter(Collider other){
			if (!IsPlayer(other)) return;

			textMessage.SetActive (true);
		}

		void OnTriggerExit(Collider other){
			if (!IsPlayer(other)) return;

			textMessage.SetActive (false);
		}
	} 
}
