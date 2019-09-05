using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public PlayerMovement plyMovement;
	public AgentScript aiScript;

	// Use this for initialization
	void Start () {


		StartCoroutine (GameLoop ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator GameLoop (){
		yield return StartCoroutine (PlayerTurn ());
		yield return StartCoroutine (AgentTurn ());
		StartCoroutine (GameLoop ());

	}

	private IEnumerator PlayerTurn(){
		plyMovement.canMove = true;
		while (plyMovement.canMove) {
			yield return null;
		}
		print ("movido");
		yield return new WaitForSeconds (0.5f);

	}

	private IEnumerator AgentTurn(){
		//aiScript.NextStep ();
		//aiScript.Move ();
		//print ("ia moved");
		yield return new WaitForSeconds (0.5f);
	}
}
