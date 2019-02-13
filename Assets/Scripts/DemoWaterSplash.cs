using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DemoWaterSplash : MonoBehaviour {

	public WaterLine _water;
	public bool _en;
	public GameObject _waterObj;
	private float _yPos;
	public float _offset;
	public UIController _pauseScript;
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
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		Invoke(nameof(GameOver), 0.5f);
	}

	public void StartWater()
	{
		_yPos = -2;
		_waterObj.transform.DOMoveY (_yPos, 2, false);
		StartCoroutine (Wawes ());
	}
	
	private void GameOver()
	{
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
