using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DemoWaterSplash : MonoBehaviour {

	[SerializeField]private WaterLine _water;	
	[SerializeField]private GameObject _waterObj;	
	
	#region PrivateFields
	private float _offset = 1.2f;
	private bool _en;
	private float _yPos;
	private int _waterLevel;
	#endregion
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (GameController.instance.isGameOver)
		{
			return;
		}
		_yPos = _yPos + _offset;
		transform.GetComponent<AudioSource>().Play ();
		_en = true;
		_waterObj.transform.DOMoveY (_yPos, 1, false);
		_waterLevel++;
		if (_waterLevel > 3)
		{
			Invoke(nameof(GameOver), 0.5f);
		}
	}

	public void StartWater()
	{
		_yPos = -5;
		_waterLevel = 0;
		_waterObj.transform.DOMoveY (_yPos, 2, false);
		StartCoroutine (Wawes ());
	}
	
	private void GameOver()
	{
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		GameController.instance.GameOver();
		_waterObj.GetComponent<AudioSource>().Play();
	}
	private void Update()
	{
		if (_en) 
		{
			_water.Splash (7, -8);
			_water.Splash (22, -8);
			_en = false;
		}
	}
	IEnumerator Wawes()
	{
		while (_yPos < 0) 
		{
			_water.Splash (25, 5);
			yield return new WaitForSeconds(2f);
		}
	}
}
