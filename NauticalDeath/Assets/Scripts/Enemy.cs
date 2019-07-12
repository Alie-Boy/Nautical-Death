using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] int scorePerHit = 10;

	[SerializeField] int hitPoints = 10;

	void Start()
	{
		AddBoxCollision();
	}

	private void AddBoxCollision()
	{
		if (GetComponent<BoxCollider>()) return;
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	void OnParticleCollision(GameObject other)
	{
		Scoreboard scoreboard = FindObjectOfType<Scoreboard>();
		scoreboard.ScoreHit(scorePerHit);
		hitPoints--;
		if (hitPoints <= 0)
		{
			KillCharacter(); 
		}
	}

	private void KillCharacter()
	{
		GameObject clone = Instantiate(deathFX, transform.position, Quaternion.identity);
		Destroy(clone, 2f);
		Destroy(gameObject);
	}
}
