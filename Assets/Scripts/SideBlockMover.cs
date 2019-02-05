using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SideBlockMover : MonoBehaviour {
	public float _xOffset;
	private float _startPos;
	
	#region UnityMethods
	private void Start () 
	{
		_startPos = transform.position.x;
	}	

	private void OnCollisionEnter2D(Collision2D other) 
	{
		Sequence _smallmoveX = DOTween.Sequence ();
		_smallmoveX.Append(transform.DOMoveX (_startPos + _xOffset, 0.1f, false));
		_smallmoveX.Append(transform.DOMoveX (_startPos, 0.1f, false));
		transform.GetComponent<AudioSource> ().Play ();
	}

	#endregion
}
