using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
				gameObject.transform.DORotate (new Vector3 (0, 0, -50), 0.11f, RotateMode.FastBeyond360)
						.SetLoops(-1,LoopType.Incremental)
						.SetEase(Ease.Linear);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
