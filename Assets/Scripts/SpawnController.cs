using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
	public GameObject rub;
	//public Vector2 spawnValues;
	public int rubCount;
		public Transform[]  _spawnPositions;
	public float spawnWait;
	public float startWait;
	private PlayerControll GC;
	//public float waveWait;
	float x,y,z;
	int sp;
	public int poolingAmount = 6;
		List<GameObject> monets;
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GC = gameControllerObject.GetComponent <PlayerControll>();
		}
		if (GC == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

				monets = new List<GameObject> ();
				for (int i = 0; i < poolingAmount; i++) 
				{
						GameObject obj = (GameObject)Instantiate (rub);
						obj.SetActive (false);
						monets.Add (obj);
				}
	}
	
	IEnumerator SpawnWaves ()
	{   

		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for (int i = 0;i < rubCount;i++) {

				sp = Random.Range(0,_spawnPositions.Length);

				Vector3 spawnPosition = _spawnPositions[sp].position;
				//Quaternion spawnRotation = Quaternion.identity;
								Quaternion spawnRotation = _spawnPositions[sp].rotation;
			//	Instantiate (rub, spawnPosition, spawnRotation);
								for (int j = 0; j < monets.Count; j++) 
								{
										if (!monets [i].activeInHierarchy) 
										{
												monets [i].transform.position = spawnPosition;
												monets [i].transform.rotation = spawnRotation;
												monets [i].SetActive (true);
												break;
										}

								}
			yield return new WaitForSeconds(spawnWait);
			}
			//yield return new WaitForSeconds(waveWait);
		}
	}
}



