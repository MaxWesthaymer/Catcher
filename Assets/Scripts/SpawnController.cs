using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
	#region InspectorFields
	[SerializeField] private  GameObject _ballPrefab;
	[SerializeField] private  Transform[]  _spawnPositions;
	#endregion
	
	#region PrivateFields
	private static float _startWait = 4f;	
	private static int _poolingAmount = 10;
	private static int _ballsCount = 10;
	private	List<GameObject> _balls;
	#endregion
	
	#region Properties	
	public float SpawnWait { set; get; }
	#endregion
	
	#region UnityMethods

	private void Awake()
	{
		SpawnWait = 3.0f;
	}

	private void Start ()
	{
		_balls = new List<GameObject> ();
			for (int i = 0; i < _poolingAmount; i++) 
			{
					GameObject obj = Instantiate (_ballPrefab);
					obj.SetActive (false);
				_balls.Add (obj);
			}
	}
	
	#endregion
	
	#region UnityMethods
	public IEnumerator SpawnWaves ()
	{   
		yield return new WaitForSeconds (_startWait);
		while(!GameController.instance.isGameOver)
		{
			for (int i = 0;i < _ballsCount;i++) {

				var positionIndex = Random.Range(0,_spawnPositions.Length);

				Vector3 spawnPosition = _spawnPositions[positionIndex].position;
				Quaternion spawnRotation = _spawnPositions[positionIndex].rotation;
			
				for (int j = 0; j < _balls.Count; j++) 
				{
					if (!_balls[i].activeInHierarchy) 
					{
						_balls[i].transform.position = spawnPosition;
						_balls[i].transform.rotation = spawnRotation;
						_balls[i].SetActive (true);
							break;
					}
				}
			yield return new WaitForSeconds(SpawnWait);
			}
		}
	}
	#endregion
}



