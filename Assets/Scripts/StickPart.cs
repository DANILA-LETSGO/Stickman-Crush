using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPart : MonoBehaviour {

	bool collision = false;

	void  OnCollisionEnter2D(Collision2D col) {
		if (col.collider.name == "Ball") {
			if (collision == false) {
				GameObject blood_clone;
				blood_clone = Instantiate (transform.parent.GetComponent<Stickman> ().blood, transform.position, Quaternion.identity);
				blood_clone.transform.parent = transform;
				collision = true;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
