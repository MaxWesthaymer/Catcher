using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	#region InspectorFields	
	[SerializeField]private int _velocity;
	[SerializeField]private Color[] _colors;
	#endregion
	
	#region PrivateFields
	private Color _newColor;
	#endregion
	
	void OnEnable()
	{
			gameObject.GetComponent<Rigidbody2D> ().velocity = transform.up * _velocity;
			_newColor = RandomColor ();
			gameObject.GetComponent<SpriteRenderer>().color = _newColor;
			gameObject.GetComponent<TrailRenderer> ().material.color = _newColor;
	}
	private Color RandomColor()
	{
			return _colors[Random.Range(0,_colors.Length)];
	}
}
