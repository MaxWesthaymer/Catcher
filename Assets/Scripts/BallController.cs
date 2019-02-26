using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	#region InspectorFields	
	[SerializeField]private Color[] _colors;
	#endregion
	
	#region PrivateFields
	private Color _newColor;
	private int _velocity;
	#endregion
	
	void OnEnable()
	{
		_velocity = GetRandomVelocity();
			gameObject.GetComponent<Rigidbody2D> ().velocity = transform.up * _velocity;
			_newColor = RandomColor ();
			gameObject.GetComponent<SpriteRenderer>().color = _newColor;
			gameObject.GetComponent<TrailRenderer> ().material.color = _newColor;
	}
	private Color RandomColor()
	{
			return _colors[Random.Range(0,_colors.Length)];
	}

	private int GetRandomVelocity()
	{
		var coef = Random.value;
		if (coef < 0.3f)
		{
			return 6;
		}
		if (coef < 0.7f)
		{
			return 8;
		}
		if (coef <= 1)
		{
			return 3;
		}
		else
		{
			return 6;
		}
	}
}
