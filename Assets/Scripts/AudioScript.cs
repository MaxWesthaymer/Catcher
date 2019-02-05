using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {
		private float _supermute;
		public GameObject _OFF;
		public GameObject _ONN;

	void Start () {
		_supermute = PlayerPrefs.GetFloat ("mutter");
		Volume (_supermute);
		Check ();
	}
	
	private void Volume (float mute)
	{
		AudioListener.volume = mute;
		PlayerPrefs.SetFloat ("mutter", mute);
	}
	private  void Check(){
		if (_supermute == 0) {
				_ONN.SetActive (false);
				_OFF.SetActive (true);
		}
		if (_supermute == 1) {
				_ONN.SetActive (true);
				_OFF.SetActive (false);
		}
	}
}
