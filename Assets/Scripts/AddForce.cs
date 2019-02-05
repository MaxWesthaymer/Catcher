using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {
		public int _velocity;
		private Color _newColor;
		public Color[] _colors;
	
		void OnEnable()
		{
				gameObject.GetComponent<Rigidbody2D> ().velocity = transform.up * _velocity;
				_newColor = RandomColor ();
				//other.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
				gameObject.GetComponent<SpriteRenderer>().color = _newColor;
				gameObject.GetComponent<TrailRenderer> ().material.color = _newColor;
		}
		public Color RandomColor()
		{
				//return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
				return _colors[Random.Range(0,_colors.Length)];
		}
}
