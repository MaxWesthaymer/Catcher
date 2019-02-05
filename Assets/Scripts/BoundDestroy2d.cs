using UnityEngine;
using System.Collections;

public class BoundDestroy2d : MonoBehaviour {
	
		void OnTriggerExit2D(Collider2D other) {
				//Destroy(other.gameObject);
				other.gameObject.SetActive(false);
				//GC.AddScore(scor);
		}
}
