using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	 int score = -1;
	private GameController GC;
	GameObject gameControllerObject;
	public GameObject sound;
	void Start()
	{
		gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null)
		{
			GC = gameControllerObject.GetComponent <GameController>();
		}
		if (GC == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		}
	void OnTriggerEnter(Collider other) 
	{
		other.gameObject.SetActive(false);
		GC.AddScore(score);
		sound.GetComponent<AudioSource>().Play ();		
	}
}