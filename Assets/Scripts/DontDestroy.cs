using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy _instance;

	void Awake () {
	    if (_instance != null)
	    {
            Destroy(gameObject);

	        return;
	    }

	    _instance = this;

	    transform.parent = null;

	    DontDestroyOnLoad(gameObject);
	}
}