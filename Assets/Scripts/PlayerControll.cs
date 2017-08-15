using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerControll : MonoBehaviour {
	public Text ScoreText;
	public int Score=0;

		public float _temprTime;
		public float _changeSpeedTime;
		public float _waitOffset;
		public HugeDOTween _hugeDoTween;
		public SpawnController _spawn;
		public SpriteRenderer _background;
		public SpriteRenderer[] _bokovuha;
		public Color[] _color1;
		public Color[] _color2;
		public Color[] _color3;
		public Color[] _color4;
		public Material _water;

	//public Button bt;

	// Use this for initialization
	void Start () {
	
				ScoreText.text = Score.ToString("00");
				StartCoroutine (Temper ());

	}
	

	public void AddScore(int NewScore)
	{
		Score += NewScore;
		
				ScoreText.text = Score.ToString("00");
				if (Score == 20) {
						DoColor (_background, _color1 [0]);
						foreach (var _bok in _bokovuha) 
						{
								DoColor (_bok, _color1 [1]);	
						}
						_water.DOColor (_color1 [2], 1);
				}
				if (Score == 40) {
						DoColor (_background, _color2 [0]);
						foreach (var _bok in _bokovuha) 
						{
								DoColor (_bok, _color2 [1]);	
						}
						_water.DOColor (_color2 [2], 1);
				}
				if (Score == 60) {
						DoColor (_background, _color3 [0]);
						foreach (var _bok in _bokovuha) 
						{
								DoColor (_bok, _color3 [1]);	
						}
						_water.DOColor (_color3 [2], 1);
				}
				if (Score == 80) {
						DoColor (_background, _color4 [0]);
						foreach (var _bok in _bokovuha) 
						{
								DoColor (_bok, _color4 [1]);	
						}
						_water.DOColor (_color4 [2], 1);
				}
		}
				
		IEnumerator Temper()
		{
				while (_spawn.spawnWait > 0.5) {
						yield return new WaitForSeconds(_temprTime);
						_spawn.spawnWait -= _waitOffset;
				}
		}
		public void DoColor (SpriteRenderer obj, Color _color)
		{
				obj.DOColor (_color, 1);
		}
	
}
