using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float zMax, zMin, xMax, xMin;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Texture ShootBTN;
	public Boundary boundary;
	public GameObject shot;
	public GameObject shot1;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;
	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//var clone : GameObject = 
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();//as GameObject
		}
		if (Input.GetButton ("Fire2") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//var clone : GameObject = 
			Instantiate(shot1, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();//as GameObject
		}
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

	}

}
