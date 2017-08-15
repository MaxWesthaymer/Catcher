using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;


public class PauseScript : MonoBehaviour  {
	bool isPause = true;
		public UnityEvent _gameOver = new UnityEvent();
	public GameObject _pauseMenu;
	public GameObject _playMenu;
	private PlayerControll GC;
	public HugeDOTween _hudeDoTween;
	public GameObject _stolb;
		public Button[] _buttons; 
		private float[] _buttonsOnStart;
		private float _stolbOnStart;
		public Text _finalScore;
		public Text _bestScore;
		public UnityEvent _exit = new UnityEvent();
		//public AppoStart _appodeal;
		public GooglePlay googleServ;
		public Text _scoreMAIN;

	// Use this for initialization
	void Start () {
				_stolbOnStart = _stolb.transform.position.y;
		Time.timeScale = 0;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GC = gameControllerObject.GetComponent <PlayerControll>();
		}
		if (GC == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
				_scoreMAIN.text = PlayerPrefs.GetInt ("higscore").ToString ("00");
	}
	
	// Update is called once per frame
	void Update () {
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
				_hudeDoTween.MoveOnY (_stolb, -3.71f, 0.5f);
				_hudeDoTween.MoveOnX (_buttons [0], -40f, 0.6f);
				_hudeDoTween.MoveOnX (_buttons [1], -40f, 0.5f);
				_hudeDoTween.MoveOnX (_buttons [2], 40f, 0.6f);
				_hudeDoTween.MoveOnX (_buttons [3], 40f, 0.5f);
				Invoke ("Help", 1);
//		PZ.enabled = true;
	}
		public void GameOver()
		{   
				_gameOver.Invoke ();
				_hudeDoTween.MoveOnY (_stolb, _stolbOnStart, 0.5f);
				_hudeDoTween.MoveOnX (_buttons [0], 45f, 0.6f);
				_hudeDoTween.MoveOnX (_buttons [1], 45f, 0.5f);
				_hudeDoTween.MoveOnX (_buttons [2], -45f, 0.6f);
				_hudeDoTween.MoveOnX (_buttons [3], -45f, 0.5f);
				_finalScore.text = GC.Score.ToString ("00");
				Highscore (GC.Score);
				_hudeDoTween.GameOverAnimation ();
				GameSessions ();
				Debug.Log ("GameOver");
		}
	
		public void Quit()	
		{
				Application.Quit();
		}
		public void Highscore(int score)
		{
				int _higscore = PlayerPrefs.GetInt ("higscore", 0);
				if (score > _higscore) {
						PlayerPrefs.SetInt ("higscore", score);
						PlayerPrefs.Save ();

				} 
				int _updateScore = PlayerPrefs.GetInt ("higscore");
				_bestScore.text = _updateScore.ToString ("00");
				googleServ.PostToLeaderboard (_updateScore);
		}
		public void Clear()
		{
				PlayerPrefs.DeleteKey ("higscore");
		}
		public void GameSessions()
		{
				int _session = PlayerPrefs.GetInt ("session", 0);
				Debug.Log (_session);
				_session++;
				PlayerPrefs.SetInt ("session", _session);
				if (_session > 1) {
						PlayerPrefs.SetInt ("session", 0);
						//_appodeal.ShowBanner ();
				}
		}
		public void Help ()
		{
				_hudeDoTween.DOHelp ();
		}

}
