using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int speed = 100;
	public bool canMove = true;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0.5f, 0.5f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	void Move () {
		if (canMove) {
			if (Input.GetKey ("w")) {
				transform.position = transform.position + new Vector3 (0, 1, 0);
				canMove = false;
			}

			if (Input.GetKey ("s")) {
				transform.position = transform.position + new Vector3 (0, -1, 0);
				canMove = false;
			}

			if (Input.GetKey ("a")) {
				transform.position = transform.position + new Vector3 (-1, 0, 0);
				canMove = false;
			}

			if (Input.GetKey ("d")) {
				transform.position = transform.position + new Vector3 (1, 0, 0);
				canMove = false;
			}
		}
	}
}
