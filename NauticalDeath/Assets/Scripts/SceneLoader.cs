using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	// Start is called before the first frame update
	void Start()
	{
		Invoke("LoadLevel", 2f);
	}

	void LoadLevel()
	{
		SceneManager.LoadScene(1);
	}

}
