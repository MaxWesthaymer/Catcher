using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SideBlockMover : MonoBehaviour {
	[SerializeField]private float _xOffset;
	private float _startPos;
	
	#region UnityMethods
	private void Start () 
	{
		//Camera cam = Camera.main;
		//float height = 2f * cam.orthographicSize;
		//float width = height * cam.aspect;
		//Debug.Log("width " + width);
		//transform.position = _xOffset > 0 ? new Vector2(width / 2f + 0.5f, 1f) : new Vector2(-width / 2f - 0.5f, 1f);
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
