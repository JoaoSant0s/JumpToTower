using UnityEngine;
using System.Collections;
namespace JumpToTower.Fields{
	public class BlocksController : MonoBehaviour {
	    [SerializeField]
	    bool direction = true;
	    [SerializeField]
	    float maxUpAndDown = 1;             // amount of meters going up and down
	    [SerializeField]
	    float speed = 100;            // up and down speed
	    float initialPosition;

	    float angle;            // angle to determin the height by using the sinus
	    protected float toDegrees   = Mathf.PI/180;    // radians to degrees

	    void Start(){
	        initialPosition = transform.position.y;
	        angle = (direction ? 0 : 360);
	    }
	     void Update(){
	        angle += speed * Time.deltaTime;
	        if (angle > 360) angle -= 360;
	        Vector3 newPosition =  (new Vector3(transform.position.x, maxUpAndDown * ( Mathf.Sin(angle * toDegrees) + initialPosition), transform.position.z));
	        transform.position = newPosition;
	    }

		public float Speed{
			set{ 
				speed = value;
			}
		}
	}
}
