using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	int scor = 1;
	private PlayerControll GC;
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GC = gameControllerObject.GetComponent <PlayerControll>();
		}
		if (GC == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


	void OnTriggerExit(Collider other) {
		//Destroy(other.gameObject);
				other.gameObject.SetActive(false);
		GC.AddScore(scor);
	}
}
