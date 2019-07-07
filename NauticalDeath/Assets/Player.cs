using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	[Tooltip("In m/s")][SerializeField] float xSpeed = 4f;
	[Tooltip("In m")]  [SerializeField] float xRange = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xThrow  = CrossPlatformInputManager.GetAxis("Horizontal");
		float xOffset = xSpeed * xThrow * Time.deltaTime;
		float xRawPos = transform.localPosition.x + xOffset;
		float xPos = Mathf.Clamp(xRawPos, -xRange, +xRange);
		transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
	}
}
