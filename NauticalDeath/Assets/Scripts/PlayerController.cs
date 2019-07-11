using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	[Tooltip("In m/s")][SerializeField] float xSpeed = 10f;
	[Tooltip("In m/s")][SerializeField] float ySpeed = 8f;
	[Tooltip("In m")]  [SerializeField] float xRange = 5f;
	[Tooltip("In m")]  [SerializeField] float yRange = 5f;
	[SerializeField] GameObject[] guns;

	[SerializeField] float positionPitchFactor = -5f;
	[SerializeField] float controlPitchFactor = -25f;
	[SerializeField] float positionYawFactor = 5f;
	[SerializeField] float controlYawFactor = -20f;

	float xThrow, yThrow;
	bool isDead = false;

	// Update is called once per frame
	void Update ()
	{
		if (isDead) return;
		ProcessPosition();
		ProcessRotation();
		ProcessFiring();
	}

	private void ProcessFiring()
	{
		if (CrossPlatformInputManager.GetButton("Fire1"))
		{
			ChangeGunActiveState(true);
		}
		else
		{
			ChangeGunActiveState(false);
		}
	}

	private void ChangeGunActiveState(bool state)
	{
		foreach (GameObject gun in guns)
		{
			gun.SetActive(state);
		}
	}

	public void DisableControls()
	{
		isDead = true;
	}

	private void ProcessRotation()
	{
		float pitch = (transform.localPosition.y * positionPitchFactor) + (yThrow * controlPitchFactor);
		float yaw   = transform.localPosition.x * positionYawFactor;
		float roll  = xThrow * controlYawFactor;
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessPosition()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xSpeed * xThrow * Time.deltaTime;
		float yOffset = ySpeed * yThrow * Time.deltaTime;

		float xRawPos = transform.localPosition.x + xOffset;
		float yRawPos = transform.localPosition.y + yOffset;

		float xPos = Mathf.Clamp(xRawPos, -xRange, +xRange);
		float yPos = Mathf.Clamp(yRawPos, -yRange, +yRange);

		transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
	}
}
