using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {

	public float speed = 8f ;
	public float acceleration = 12f;
	public float gravity = 20f;

	public float jumpHeight = 10f;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics> ();

		transform.rotate
	}
	
	// Update is called once per frame
	void Update () {

		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}

		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = incrementTowards (currentSpeed , targetSpeed , acceleration);
		//Debug.Log (targetSpeed);

		if (playerPhysics.grounded) {
			if(Input.GetButtonDown("Jump")){
				amountToMove.y = jumpHeight;
			}		
		}

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;

		playerPhysics.moveTo (amountToMove * Time.deltaTime);
	}

	private float incrementTowards(float n , float target , float a){
		if(n == target){
			return n;
		}
		float dir = Mathf.Sign (target - n);
		n += a * Time.deltaTime * dir;
		return (dir == Mathf.Sign (target - n))? n: target;
	}
}
