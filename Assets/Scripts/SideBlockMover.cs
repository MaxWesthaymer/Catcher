using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SideBlockMover : MonoBehaviour {
	[SerializeField]private float _xOffset;
	private float _startPos;
	
	#region UnityMethods
	private void Start () 
	{
		_startPos = transform.position.x;
	}	

	private void OnCollisionEnter2D() 
	{
		var smallmoveX = DOTween.Sequence ();
		smallmoveX.Append(transform.DOMoveX (_startPos + _xOffset, 0.1f));
		smallmoveX.Append(transform.DOMoveX (_startPos, 0.1f));
		transform.GetComponent<AudioSource> ().Play ();
	}

	#endregion
}
