using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
		public Transform[] _playerPositions;
		private Vector3 _startPosition;
		public float _moveSpeed;

		int score = 1;
		private GameController GC;
		GameObject gameControllerObject;
		public GameObject sound;
		public UnityEvent _onTriggerEnter = new UnityEvent();
		public Color _playerColor;
		public GameObject[] _colorizeObjects;
		public GameObject _explosion;
		public Text _score;

	// Use this for initialization
	void Start () {
				_startPosition = new Vector3 (0, -0.21f, -1.02f);
				//transform.DOPunchPosition(new Vector3( 0,0.2f,0),1,2,1,false).SetLoops(-1,LoopType.Yoyo);
				gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

				if (gameControllerObject != null)
				{
						GC = gameControllerObject.GetComponent <GameController >();
				}
				if (GC == null)
				{
						Debug.Log ("Cannot find 'GameController' script");
				}
				_playerColor = gameObject.GetComponent<SpriteRenderer> ().color;
				Sequence _player = DOTween.Sequence ();
				_player.Append(transform.DOLocalMoveY (-0.21f, 0.5f, false).SetEase (Ease.InOutSine));
				_player.Append(_score.DOFade (1, 1f).SetEase (Ease.Flash, 15, 1));


	}
		void OnTriggerEnter2D(Collider2D other)
		{
				other.gameObject.SetActive (false);
				GC.AddScore (score);
				//sound.GetComponent<AudioSource>().Play ();
				_onTriggerEnter.Invoke ();
				DoScale (other);
				_playerColor = other.gameObject.GetComponent<SpriteRenderer> ().color;
				_colorizeObjects [0].GetComponent<SpriteRenderer> ().color = _playerColor;
				_explosion.GetComponent<ParticleSystem> ().startColor = _playerColor;
				_explosion.SetActive (true);
				var _newExpl = Instantiate (_explosion, transform.position, transform.rotation) as GameObject;
				_newExpl.transform.parent = gameObject.transform;
				Destroy (_newExpl, 2);
		}
		public void MoveTo(int _num)
		{
				Sequence _movePos = DOTween.Sequence ();
				_movePos.Append(transform.DOMove (_playerPositions[_num].position, _moveSpeed, false));
				_movePos.Append(transform.DOMove (_startPosition, _moveSpeed, false));	
		}
		public void PointerUP()
		{
				transform.DOMove (_startPosition, _moveSpeed, false);	

		}
		public void DoScale(Collider2D obj)
		{
				Sequence _scale = DOTween.Sequence ();
				_scale.Append(transform.DOScale (1.15f, 0.2f).SetEase(Ease.InOutQuad));
				_scale.Join(obj.gameObject.transform.DOMove(transform.position,0.2f,false));

				_scale.Append(transform.DOScale (1f, 0.2f));
		}
		public void playerGameOver()
		{
				transform.DOLocalMoveY (-10f, 10, false);
		}


				
}
