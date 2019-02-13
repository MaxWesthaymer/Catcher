using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIController : MonoBehaviour  {
	#region InspectorFields	
	[SerializeField] private GameObject _playMenu;
	[SerializeField] private HugeDOTween _hudeDoTween;
	[SerializeField] private GameObject _stolb;
	[SerializeField] private Button[] _buttons; 
	
	[SerializeField] private Text _finalScore;
	[SerializeField] private Text _bestScore;
	[SerializeField] private Text _scoreMAIN;	
	[SerializeField] private GameObject _gameOverBackGround;	
	[SerializeField] private GameObject _gameOverMenu;	
	#endregion
	
	#region PrivateFields
	private float[] _buttonsOnStart;
	private float _stolbOnStart;
	
	#endregion

	#region UnityMethods
	private void Start () 
	{
		_stolbOnStart = _stolb.transform.position.y;		
		_scoreMAIN.text = PlayerPrefs.GetInt ("higscore").ToString ("00");
	}
	
	#endregion
	
	#region Methods
	
	public void StartGame() //Runing from inspector
	{  
		GameController.instance.StartGame();
		_playMenu.SetActive (false);
		_hudeDoTween.MoveOnY (_stolb, -3.71f);
		var btnSize = _buttons[0].GetComponent<RectTransform>().sizeDelta.x;
		_hudeDoTween.MoveOnX (_buttons [0], btnSize * -1.3f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [1], btnSize * -1.5f, 0.5f);
		_hudeDoTween.MoveOnX (_buttons [2], btnSize * 1.3f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [3], btnSize * 1.5f, 0.5f);
		Invoke(nameof(Help), 1);
		_stolb.GetComponent<AudioSource>().Play();
	}
	public void GameOver()
	{   	
		_gameOverBackGround.SetActive(true);
		_gameOverMenu.SetActive(true);
		_hudeDoTween.MoveOnY (_stolb, _stolbOnStart);
		var btnSize = _buttons[0].GetComponent<RectTransform>().sizeDelta.x;
		_hudeDoTween.MoveOnX (_buttons [0], btnSize * 2f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [1], btnSize * 2f, 0.5f);
		_hudeDoTween.MoveOnX (_buttons [2], btnSize * -2f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [3], btnSize * -2f, 0.5f);
		_finalScore.text = GameController.instance.Score.ToString ("00");
		Highscore (GameController.instance.Score);
		_hudeDoTween.GameOverAnimation ();
		GameSessions ();
		Debug.Log ("GameOver");
	}
	

	private void Highscore(int score)
	{
		int _higscore = PlayerPrefs.GetInt ("higscore", 0);
		if (score > _higscore) 
		{
			PlayerPrefs.SetInt ("higscore", score);
			PlayerPrefs.Save ();
		} 
		int _updateScore = PlayerPrefs.GetInt ("higscore");
		_bestScore.text = _updateScore.ToString ("00");
	}

	private void GameSessions()
	{
			int _session = PlayerPrefs.GetInt ("session", 0);
			Debug.Log (_session);
			_session++;
			PlayerPrefs.SetInt ("session", _session);
			if (_session > 1) {
					PlayerPrefs.SetInt ("session", 0);
			}
	}
	private void Help ()
	{
		_hudeDoTween.DOHelp ();
	}
	#endregion
}
