using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CallEvent : MonoBehaviour {
		public UnityEvent _event = new UnityEvent();
	
		public void DOEvent()
		{
				_event.Invoke ();
		}
}
