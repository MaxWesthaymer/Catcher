using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	#region InspectorFields	
	[SerializeField] private float _moveSpeed;
	[SerializeField] private Color _playerColor;
	[SerializeField] private GameObject[] _colorizeObjects;
	[SerializeField] private GameObject _explosion;
	[SerializeField] private Text _score;

	#endregion
	
	#region PrivateFields
	private AudioSource _playerAudio;
	private Vector3 _startPosition;
	private static Vector2[] _playerPositions = { new Vector2(1.4f, -0.21f), new Vector2(-1.4f, -0.21f), new Vector2(1.01f,0.59f), new Vector2(-1.01f, 0.59f)};
	#endregion
	
	#region UnityMethods
	private void Start ()
	{
		_playerAudio = GetComponent<AudioSource>();
		_startPosition = new Vector3 (0, -0.21f, -1.02f);
		_playerColor = gameObject.GetComponent<SpriteRenderer> ().color;

		var player = DOTween.Sequence ();
		player.Append(transform.DOLocalMoveY (-0.21f, 0.5f).SetEase (Ease.InOutSine));
		player.Append(_score.DOFade (1, 1f).SetEase (Ease.Flash, 15, 1));
	}
		
	private void OnTriggerEnter2D(Collider2D other)
	{
		other.gameObject.SetActive (false);
		GameController.instance.AddScore();
		_playerAudio.Play();
		
		DoScale (other);
		_playerColor = other.gameObject.GetComponent<SpriteRenderer> ().color;
		_colorizeObjects [0].GetComponent<SpriteRenderer> ().color = _playerColor;
		_explosion.GetComponent<ParticleSystem> ().startColor = _playerColor;
		_explosion.SetActive (true);
		
		var newExpl = Instantiate (_explosion, transform.position, transform.rotation);  //todo Play ParticleSystem like Snatty
		newExpl.transform.parent = gameObject.transform;
		Destroy (newExpl, 2);
	}
	#endregion
	
	public void MoveTo(int num)
	{
			var movePos = DOTween.Sequence ();
			movePos.Append(transform.DOMove (_playerPositions[num], _moveSpeed));
			movePos.Append(transform.DOMove (_startPosition, _moveSpeed));	
	}
	public void PointerUP()
	{
			transform.DOMove (_startPosition, _moveSpeed);	
	}
	private void DoScale(Collider2D obj)
	{
			var scale = DOTween.Sequence ();
			scale.Append(transform.DOScale (1.15f, 0.2f).SetEase(Ease.InOutQuad));
			scale.Join(obj.gameObject.transform.DOMove(transform.position,0.2f));
			scale.Append(transform.DOScale (1f, 0.2f));
	}
	public void playerGameOver()
	{
		_explosion.GetComponent<ParticleSystem>().Stop();
		transform.DOLocalMoveY (-10f, 10);
	}				
}
