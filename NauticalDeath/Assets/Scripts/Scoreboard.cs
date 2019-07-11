using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	int score;
	Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ScoreHit(int scorePerHit)
	{
		score += scorePerHit;
		scoreText.text = score.ToString();
	}
}
