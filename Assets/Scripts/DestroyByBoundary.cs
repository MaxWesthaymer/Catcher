using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	int scor = 1;
	private GameController GC;
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GC = gameControllerObject.GetComponent <GameController>();
		}
		if (GC == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


	void OnTriggerExit(Collider other) 
	{
		other.gameObject.SetActive(false);
		GC.AddScore(scor);
	}
}
