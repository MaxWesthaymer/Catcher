using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SideBlockMovier : MonoBehaviour {
		public float _xOffset;
		private float _startPos;
	// Use this for initialization
	void Start () {
				_startPos = transform.position.x;
	}
	

		void OnCollisionEnter2D(Collision2D other) 
		{
				Sequence _smallmoveX = DOTween.Sequence ();
				_smallmoveX.Append(transform.DOMoveX (_startPos + _xOffset, 0.1f, false));
				_smallmoveX.Append(transform.DOMoveX (_startPos, 0.1f, false));
				transform.GetComponent<AudioSource> ().Play ();
		}
}
