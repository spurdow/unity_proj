using UnityEngine;
using System.Collections;

public class PrefabOnRuntimeScript : MonoBehaviour {

	private GameObject ground1;
	private GameObject ground2;

	private Vector2 start_pos1;
	private Vector2 start_pos2;

	float speed = 15f;
	// Use this for initialization
	void Start () 
	{
		ground1 = Instantiate (Resources.Load ("Prefabs/ground1", typeof(GameObject))) as GameObject;
		ground2 = Instantiate (Resources.Load ("Prefabs/ground2", typeof(GameObject))) as GameObject;

		start_pos1 = ground1.transform.position;
		start_pos2 = ground2.transform.position;
		
	}
	
	void FixedUpdate()
	{
		updateGround ();

	}

	private void updateGround()
	{
		Vector2 g1_position = ground1.transform.position;
		Vector2 g2_position = ground2.transform.position;

			

		if (g1_position.x <= -39.00) 
		{
			g1_position.x = start_pos2.x;

		}else if(g2_position.x <= -39){
			g2_position.x = start_pos2.x;
		}


		g1_position.x += -0.01f * speed ;
		g2_position.x += -0.01f * speed;
		ground1.transform.position = g1_position;
		ground2.transform.position = g2_position;



	}
}
