using UnityEngine;
using System.Collections;
namespace JumpToTower.Player{
	public class InputController : MonoBehaviour {
		PlayerController character;
		bool jump;

		void Awake(){
			character = GetComponent<PlayerController>();
		}

		void Update(){
			jump = Input.GetButtonDown ("Jump");
		}

		void FixedUpdate(){
			Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0);
			
			character.Move(input.normalized, jump);
			
			jump = false;
		}
	}
}