using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DectroyByContact2D : MonoBehaviour {
		int score = 1;
		private GameController GC;
		GameObject gameControllerObject;
		public GameObject sound;
		public UnityEvent _onTriggerEnter = new UnityEvent();
	// Use this for initialization
	void Start () {
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
		void OnTriggerEnter2D(Collider2D other) 
		{
				other.gameObject.SetActive(false);
				GC.AddScore(score);
				//sound.GetComponent<AudioSource>().Play ();
				_onTriggerEnter.Invoke();
		}
}
