using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashInputHandler : MonoBehaviour
{

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

    // Start is called before the first frame update
    void Start()
    {
		Invoke("LoadLevel", 2f);
    }

	void LoadLevel()
	{
		SceneManager.LoadScene(1);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
