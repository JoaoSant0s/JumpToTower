using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	float speed = 5f;

	[SerializeField] 
	float jumpForce = 350f;
	[SerializeField] 
	float groundedRadius = .2f;

	[SerializeField]
	LayerMask whatIsGround;
	
	Vector3 velocity;

	Rigidbody rigidbody;
	bool grounded = false;
	Transform groundCheck;								// A position marking where to check if the player is grounded.



	void Awake () {
		groundCheck = transform.Find("GroundCheck");
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate(){
		grounded = Physics.OverlapSphere(groundCheck.position, groundedRadius, whatIsGround).Length > 0;
		rigidbody.position += velocity * Time.deltaTime;
	}
	
	public void Move(Vector2 direction, bool jump ){
		velocity = direction * speed;

		if (grounded && jump) {
			rigidbody.AddForce (new Vector2 (0f, jumpForce));
		}
	}
}
