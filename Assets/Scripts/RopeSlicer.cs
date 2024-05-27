using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSlicer : MonoBehaviour {

	public GameObject ray_point; // из инспектора.
	Transform first_point;
	Transform second_point;
	GameObject new_ray_point;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector3 mouse_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouse_position += new Vector3 (0, 0, 10);

			transform.position = mouse_position;

			new_ray_point = Instantiate (ray_point, mouse_position, Quaternion.identity);

			if (second_point == true) {
				first_point = second_point;
				second_point = new_ray_point.transform;

				Vector3 direction = second_point.position - first_point.position;

				Debug.DrawRay (first_point.position, direction, new Color(1,1,0), 100);

				float ray_length = Vector3.Distance (first_point.position, second_point.position);


				RaycastHit2D[] hit = Physics2D.RaycastAll (first_point.position, direction, ray_length);

				if (hit.Length > 0) {
					for (int i = 0; i < hit.Length; i++) {
						if (hit[i].transform.tag == "Rope" || hit[i].transform.tag == "Meat") {
							if (hit [i].transform.GetComponent<HingeJoint2D> () == true) {
								Destroy (hit [i].transform.GetComponent<HingeJoint2D> ());
								hit [i].transform.GetComponent<Rigidbody2D> ().AddForce (new Vector2( Random.Range (-2000, 2000), Random.Range (-2000, 2000)));
								FindObjectOfType<ScoreLevel> ().Start_Timer ();
							}
						}
					}
				}
			}

			if (first_point == true) {
				second_point = new_ray_point.transform;
			}

		}

	  	if (Input.GetMouseButtonDown (0)) {
			first_point = new_ray_point.transform;
		}
		if (Input.GetMouseButtonUp (0)) {
			first_point = null;
			second_point = null;
		}		
		
	}
}
