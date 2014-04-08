using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {

	public float swipeThreshold = 1.2f;
	public Vector2 swipeStart = Vector2.zero;
	public Vector2 swipeEnd = Vector2.zero;
	public bool swipeActive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			processSwipe();		
		}
	}

	void onGUI(){
		processSwipe ();
		drawStartBox ();
		drawEndBox ();
	}


	void processSwipe(){
		if (Input.touchCount == 1) {
			return;		
		}

		Touch theTouch = Input.touches [0];

		/* skip the frame if deltaPosition is zero*/

		if (theTouch.deltaPosition == Vector2.zero) {
			return;		
		}

		Vector2 speedVec = theTouch.deltaPosition;
		float theSpeed = speedVec.magnitude;

		bool swipeIsActive = (theSpeed > swipeThreshold);

		if ( swipeIsActive ) {
			if( !swipeActive ){
				swipeStart = theTouch.position;
			}		
		}else{
			if( swipeIsActive ){
				swipeEnd = theTouch.position;
				Debug.Log("Swipe Complete");
			}
		}

	}

	void drawStartBox(){
		if (swipeStart == Vector2.zero) {
			return;
		}

		float theY = Screen.height - swipeStart.y;
		float theX = swipeStart.x;

	
		Rect theRect = new Rect (theX , theY , 140 , 40);

		
	}

	void drawEndBox(){
		if (swipeEnd == Vector2.zero) {
			return;
		}


		float theY = Screen.height - swipeEnd.y;
		float theX = swipeEnd.x;

		Rect theRect = new Rect (theX , theY , 140, 40);
	}
}
