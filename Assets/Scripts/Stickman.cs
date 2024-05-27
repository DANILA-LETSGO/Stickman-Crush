using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour {

	public bool fall = false;
	public GameObject blood;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.transform.name == "Ball") {
			
			fall = true;

			for (int i = 0; i < 7; i++) {
				transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().simulated = true;

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
