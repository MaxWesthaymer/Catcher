using UnityEngine;
using System.Collections;

public class Asteromove : MonoBehaviour {

	
	public float speed;
	void OnEnable()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
