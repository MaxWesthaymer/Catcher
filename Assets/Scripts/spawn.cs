using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
	public GameObject Aster;
	public Transform ASpawn;
	public float fireRate;
	private float nextFire;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//var clone : GameObject = 
			Instantiate(Aster, ASpawn.position, ASpawn.rotation); //as GameObject
		}
	}
}
