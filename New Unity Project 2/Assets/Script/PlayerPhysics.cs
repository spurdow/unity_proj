﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider collider;

	private Vector3 s;
	private Vector3 c;

	private float skin = 0.005f;

	public bool movementStopped;

	//[HideInInspector]
	public bool grounded;

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider> ();
		s = collider.size;
		c = collider.center;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveTo(Vector2 amount){

		float deltaY = amount.y;
		float deltaX = amount.x;

		Vector2 p = transform.position;
		//float dir = Mathf.Sign (deltaY);
		grounded = false;
		for(int i = 0 ; i < 3 ; i++){
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + c.x - s.x / 2) + s.x/2 * i;
			float y = p.y + c.y + s.y / 2 * dir;


			 

			ray = new Ray (new Vector2(x , y) , new Vector2(0 , dir));
			//Debug.DrawRay(ray.origin , ray.direction);
			if(Physics.Raycast (ray , out hit , Mathf.Abs(deltaY) + skin, collisionMask)){
				float dst = Vector3.Distance(ray.origin , hit.point);

				if(dst > skin){
					deltaY = dst * dir - skin  * dir;
				}else{
					deltaY = 0;
				}
				grounded = true;
				break;
			}

		}
		movementStopped = false;
		for(int i = 0 ; i < 3 ; i++){
			float dir = Mathf.Sign(deltaX);
			float x = p.x + c.x + s.x / 2 * dir;
			float y = p.y + c.y - s.y / 2 * + s.y / 2 * i;
			
			ray = new Ray (new Vector2(x , y) , new Vector2(dir , 0));
			//Debug.DrawRay(ray.origin , ray.direction);
			if(Physics.Raycast (ray , out hit , Mathf.Abs(deltaX) + skin, collisionMask)){
				float dst = Vector3.Distance(ray.origin , hit.point);
				
				if(dst > skin){
					deltaX = dst * dir - skin * dir;
				}else{
					deltaX = 0;
				}
				movementStopped = true;
				break;
			}
			
		}

		Vector3 playerDir = new Vector3 (deltaX , deltaY);
		Vector3 o = new Vector3 ( p.x + c.x + s.x / 2 * Mathf.Sign(deltaX) ,p.y + c.y + s.y / 2 * Mathf.Sign(deltaY));
		Debug.DrawRay (o , playerDir);

		Vector2 finalTransform = new Vector2 (deltaX , deltaY);


		transform.Translate (finalTransform);
	}
}
