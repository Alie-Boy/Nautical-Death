using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashInputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Invoke("LoadLevel", 2f);
    }

	void LoadLevel()
	{
		DontDestroyOnLoad(this);
		SceneManager.LoadScene(1);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
