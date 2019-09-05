using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {

	private Vector3 aiPos;
	private int index;
	private float function = 10000000000000;
	private GameObject objective;
	private float nextDist;
	private Vector3[] nextCPlat = {
		new Vector3 (0f, 1f, 0f),
		new Vector3 (0f, -1f, 0f),
		new Vector3 (1f, 0f, 0f),
		new Vector3 (-1f, 0f, 0f)

	};

	private Vector3[] nextCBarrier = {
		new Vector3 (0f, 0.5f, 0f),
		new Vector3 (0f, -0.5f, 0f),
		new Vector3 (0.5f, 0f, 0f),
		new Vector3 (-0.5f, 0f, 0f)
	};
	private GameObject[] platforms;
	private GameObject[] barriers;
	private GameObject[] nextPlat = new GameObject[4];


	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (2.5f, 0.5f, 0.0f);
		objective = GameObject.FindGameObjectWithTag ("Player");
		platforms = GameObject.FindGameObjectsWithTag ("Platform");
     	barriers = GameObject.FindGameObjectsWithTag ("Barrier");
	}
	
	// Update is called once per frame
	void Update () {
		aiPos = transform.position;

	}

	public void NextStep(){
		
		objective = GameObject.FindGameObjectWithTag ("Player");
		bool blocked = false;
		float currentFunction;

		foreach(GameObject found in platforms) {
			Vector3 pos = found.transform.position;
			if (pos == aiPos + nextCPlat[0]) {
				nextPlat[0] = found;
			}
			if (pos == aiPos + nextCPlat[1]) {
				nextPlat[1] = found;
			}
			if (pos == aiPos + nextCPlat[2]) {
				nextPlat[2] = found;
			}
			if (pos == aiPos + nextCPlat[3]) {
				nextPlat[3] = found;
			}
		}

		float distance = (objective.transform.position.x - aiPos.x) + (objective.transform.position.y - aiPos.y);
		distance = Mathf.Abs (distance);
		print (distance);

		for (int i = 0; i < nextPlat.Length; i++) {
			foreach (GameObject block in barriers) {
				if (block.transform.position == aiPos + nextCBarrier [i]) {
					blocked = true;
				}
			}

			if (blocked) {
				blocked = false;
				continue;
			}

			Vector3 newDist = aiPos + nextPlat[i].transform.position;
			print (newDist);
			float platDistance = (objective.transform.position.x - newDist.x) + (objective.transform.position.y - newDist.y);
			platDistance = Mathf.Abs (platDistance);
			print (platDistance);

			currentFunction = platDistance + nextPlat [i].GetComponent<PlatProperties> ().cost;

			if (currentFunction < function) {
				function = currentFunction;
				index = i;
			}


		}
	}

	public void Move (){
		transform.position = nextPlat [index].transform.position;
		index = -1;
		function = 10000000000000;
	}
}
