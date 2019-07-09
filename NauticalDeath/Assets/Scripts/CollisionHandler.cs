using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

	[SerializeField] float levelLoadDelay = 1f;
	[SerializeField] GameObject deathFX;

	void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
	}

	private void StartDeathSequence()
	{
		SendMessage("DisableControls");
		deathFX.SetActive(true);
		Invoke("RestartLevel", levelLoadDelay);
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(1);
	}
}
