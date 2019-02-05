using UnityEngine;
using System.Collections;

public class BoundDestroy : MonoBehaviour 
{
	   void OnTriggerExit2D(Collider2D other) 
	   {
	   		other.gameObject.SetActive(false);
	   }
}
