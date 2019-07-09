using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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
		Destroy(gameObject);
	}
}
