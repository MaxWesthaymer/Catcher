using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIController : MonoBehaviour  {
	#region InspectorFields	
	[SerializeField] private UnityEvent _gameOver = new UnityEvent();
	[SerializeField] private GameObject _pauseMenu;
	[SerializeField] private GameObject _playMenu;
	[SerializeField] private HugeDOTween _hudeDoTween;
	[SerializeField] private GameObject _stolb;
	[SerializeField] private Button[] _buttons; 
	
	[SerializeField] private Text _finalScore;
	[SerializeField] private Text _bestScore;
	[SerializeField] private UnityEvent _exit = new UnityEvent();
	[SerializeField] private Text _scoreMAIN;	
	#endregion
	
	#region PrivateFields
	private float[] _buttonsOnStart;
	private float _stolbOnStart;
	bool isPause = true;	
	#endregion

	#region UnityMethods
	private void Start () 
	{
		_stolbOnStart = _stolb.transform.position.y;
		Time.timeScale = 0;  //todo убрать
		_scoreMAIN.text = PlayerPrefs.GetInt ("higscore").ToString ("00");
	}
	
	private void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log ("Escape is pressed");
			//if (Application.platform == RuntimePlatform.Android)
			if(isPause)
			{
					//Application.Quit();
					_exit.Invoke();
				Debug.Log("Open dialog");
			}
		}
	}
	#endregion
	
	#region Methods
	public void pauze()
	{   
		isPause = !isPause;
		if (isPause) 
		    Time.timeScale = 0;
		else
			Time.timeScale = 1;
				_pauseMenu.SetActive (isPause);

	}
	public void ReStart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void Pusk()
		{   
		isPause = false;
		Time.timeScale = 1;
		_playMenu.SetActive (false);
		_hudeDoTween.MoveOnY (_stolb, -3.71f);
		_hudeDoTween.MoveOnX (_buttons [0], -40f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [1], -40f, 0.5f);
		_hudeDoTween.MoveOnX (_buttons [2], 40f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [3], 40f, 0.5f);
		Invoke(nameof(Help), 1);
	}
	public void GameOver()
	{   
		_gameOver.Invoke ();
		_hudeDoTween.MoveOnY (_stolb, _stolbOnStart);
		_hudeDoTween.MoveOnX (_buttons [0], 45f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [1], 45f, 0.5f);
		_hudeDoTween.MoveOnX (_buttons [2], -45f, 0.6f);
		_hudeDoTween.MoveOnX (_buttons [3], -45f, 0.5f);
		_finalScore.text = GameController.instance.Score.ToString ("00");
		Highscore (GameController.instance.Score);
		_hudeDoTween.GameOverAnimation ();
		GameSessions ();
		Debug.Log ("GameOver");
	}
	
	public void Quit()	
	{
		Application.Quit();
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
	public void Clear()
	{
			PlayerPrefs.DeleteKey ("higscore");
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
