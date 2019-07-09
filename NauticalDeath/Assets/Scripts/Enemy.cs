using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;

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
		GameObject clone = Instantiate(deathFX, transform.position, Quaternion.identity);
		Destroy(clone, 2f);
		Destroy(gameObject);
	}
}
