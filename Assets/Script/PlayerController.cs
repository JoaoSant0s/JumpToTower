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
	Transform groundCheck;

    Camera mainCamera;// A position marking where to check if the player is grounded.



	void Awake () {
        mainCamera = Camera.main;
        groundCheck = transform.Find("GroundCheck");
		rigidbody = GetComponent<Rigidbody> ();
	}

    void UpdatePlayerParent(){
        if (grounded){
            transform.parent = Physics.OverlapSphere(groundCheck.position, groundedRadius, whatIsGround)[0].transform;
        }
        else{
            transform.parent = null;
        }
    }
	
	void FixedUpdate(){
		grounded = Physics.OverlapSphere(groundCheck.position, groundedRadius, whatIsGround).Length > 0;
        UpdatePlayerParent();

        rigidbody.position += velocity * Time.deltaTime;
	}
	
	public void Move(Vector2 direction, bool jump ){
		velocity = direction * speed;
        
		if (grounded && jump) {
			rigidbody.AddForce (new Vector2 (0f, jumpForce));
		}

        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
