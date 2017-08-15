using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	//public GameObject explosion;
	//public GameObject playerExplosion;
	 int score = -1;
	private PlayerControll GC;
	GameObject gameControllerObject;
	public GameObject sound;
	void Start()
	{
		gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null)
		{
			GC = gameControllerObject.GetComponent <PlayerControll>();
		}
		if (GC == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		}
	void OnTriggerEnter(Collider other) 
	{
//		if (other.tag == "korzina")
//		{
//			return;
//		}
//		Instantiate(explosion, transform.position, transform.rotation);
//		if (other.tag == "Player")
//		{
//			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
//		}
		//Destroy(other.gameObject);
				other.gameObject.SetActive(false);
		//Destroy(gameObject);
		GC.AddScore(score);
	//	if (sound. == true){
		sound.GetComponent<AudioSource>().Play ();
		//}
	}
}