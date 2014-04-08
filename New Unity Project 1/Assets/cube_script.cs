using UnityEngine;
using System.Collections;

public class cube_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.down , 10f * Time.deltaTime);
	}
}
