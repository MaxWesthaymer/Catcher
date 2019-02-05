using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DemoWaterSplash : MonoBehaviour {

	public WaterLine _water;
	public bool _en;
	public GameObject _waterObj;
	private float _yPos;
	public float _offset;
	public PauseScript _pauseScript;
	private void Start()
	{
			_yPos = -2;
			_waterObj.transform.DOMoveY (_yPos, 2, false);
			StartCoroutine (Wawes ());
	}
	private void OnTriggerEnter2D(Collider2D coll)
	{	
		_yPos = _yPos + _offset;
		transform.GetComponent<AudioSource>().Play ();
		_en = true;
		_waterObj.transform.DOMoveY (_yPos, 1, false);
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		Invoke(nameof(GameOver), 0.5f);
	}
	private void GameOver()
	{
		_pauseScript.GameOver ();
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
