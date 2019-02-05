using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour 
{
	#region InspectorFields
	[SerializeField] private Text _scoreText;
	[SerializeField] private float _temprTime;
	[SerializeField] private float _waitOffset;
	[SerializeField] private SpawnController _spawn;
	[SerializeField] private SpriteRenderer _background;
	[SerializeField] private SpriteRenderer[] _bokovuha;
	[SerializeField] private Color[] _color1;
	[SerializeField] private Color[] _color2;
	[SerializeField] private Color[] _color3;
	[SerializeField] private Color[] _color4;
	[SerializeField] private Material _water;
	#endregion
	
	#region PrivateFields

	private int _colorChangeCounter;
	#endregion
	
	#region Public Fields
	public static GameController instance;
	#endregion

	#region Properties	
	public int Score { set; get;}
    #endregion
	
	#region UnityMethods

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void Start ()
	{
		SetRandomColor();
		_scoreText.text = Score.ToString("00");
		_colorChangeCounter = 0;
		StartCoroutine(Temper());
	}
	#endregion

	public void AddScore(int newScore)
	{
		Score += newScore;
		_colorChangeCounter++;
		_scoreText.text = Score.ToString("00");
		if (_colorChangeCounter >= 10)
			{
				SetRandomColor();
				_colorChangeCounter = 0;
			}	
		}
				
	private  IEnumerator Temper() //изменение сложности игры
	{
			while (_spawn.spawnWait > 0.5) {
					yield return new WaitForSeconds(_temprTime);
					_spawn.spawnWait -= _waitOffset;
			}
	}		

	private void SetRandomColor()
	{
		var num = Random.Range(0, 4);
		switch (num)
		{
			case 0:
				SetColor(_color1);
				break;
			case 1:
				SetColor(_color2);
				break;
			case 2:
				SetColor(_color3);
				break;
			case 3:
				SetColor(_color4);
				break;
		}
	}

	private void SetColor(Color[] palette)
	{
		DoColor (_background, palette [0]);
		foreach (var it in _bokovuha) 
		{
			DoColor (it, palette [1]);	
		}
		_water.DOColor (palette [2], 1);
	}
	
	private void DoColor (SpriteRenderer obj, Color color)
	{
		obj.DOColor (color, 1);
	}
}
