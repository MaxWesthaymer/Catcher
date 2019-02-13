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
	[SerializeField] private Button _replayBtn; 
	[SerializeField] private Button _shareBtn; 
	[SerializeField] private Button _leaderBtn; 
	
	[SerializeField] private Text _finalScore;
	[SerializeField] private Text _bestScore;
	[SerializeField] private Text _scoreMAIN;	
	[SerializeField] private GameObject _gameOverBackGround;	
	[SerializeField] private GameObject _gameOverMenu;	
	
	[SerializeField] private Button _audioBtn;
	[SerializeField] private Sprite _audioOn;
	[SerializeField] private Sprite _audioOff;
	#endregion
	
	#region PrivateFields
	private float[] _buttonsOnStart;
	private float _stolbOnStart;
	private AudioSource _audioSourceBtn;
	#endregion

	#region UnityMethods

	private void Awake()
	{
		_audioSourceBtn = gameObject.GetComponent<AudioSource>();
		_replayBtn.onClick.AddListener(() => {_audioSourceBtn.Play(); GameController.instance.ReStart(); });
		_shareBtn.onClick.AddListener(() => {GameController.instance.ReStart(); _audioSourceBtn.Play();});
		_leaderBtn.onClick.AddListener(() => {GameController.instance.ReStart(); _audioSourceBtn.Play();});
		_audioBtn.onClick.AddListener(() => {Volume(); _audioSourceBtn.Play();});
	}

	private void Start () 
	{
		_stolbOnStart = _stolb.transform.position.y;		
		_scoreMAIN.text = PlayerPrefs.GetInt ("higscore").ToString ("00");
		AudioListener.volume = PlayerPrefs.GetFloat ("mutter");
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
	
	private void Volume ()
	{
		_audioSourceBtn.Play();
		if (AudioListener.volume >= 1)
		{
			AudioListener.volume = 0;
			PlayerPrefs.SetFloat ("mutter", 0);
			_audioBtn.GetComponent<Image>().sprite = _audioOff;
		}
		else
		{
			AudioListener.volume = 1;
			PlayerPrefs.SetFloat ("mutter", 1);
			_audioBtn.GetComponent<Image>().sprite = _audioOn;
		}		
	}
	#endregion
}
