using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour 
{

	private int playerHealth; 
	public int score;
	public float time;
	public Slider healthBar;
	Text hudText;




	public void StartNewGame()
	{
		score = 0;
		time = 0;
		playerHealth = 4;

	}
	public void StorePlayerValues()
	{
		PlayerPrefs.SetInt ("Score", score);
		PlayerPrefs.SetFloat ("Time", time);
		PlayerPrefs.SetInt ("Health", playerHealth);
	}

	public void RestorePlayerValues() 
	{
		score = PlayerPrefs.GetInt ("Score");
		time = PlayerPrefs.GetFloat ("Time");
		playerHealth = PlayerPrefs.GetInt ("Health");

	}
	
	public void DeletePlayerValues() 
	{
		PlayerPrefs.DeleteKey ("Score");
		PlayerPrefs.DeleteKey ("Time");

	}

	void Awake()
	{
		if (Application.loadedLevel != 1) 
		{
			if (PlayerPrefs.GetFloat ("Time") != 0)
				RestorePlayerValues ();
			else
				StartNewGame ();
		}
		else
			StartNewGame ();


	}


	// Use this for initialization
	void Start () 
	{
		hudText = GameObject.Find ("GameMessage").GetComponent<Text> ();
	}


	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;
		hudText.text = "Time: " + (int)time + " Score: " + score;
		healthBar.value = playerHealth;

	}
	//Respawn when player dies. Gives back full health
	public void Respawn()
	{
		GameObject.FindGameObjectWithTag("GamePlayers").gameObject.transform.position = GameObject.Find ("respawn").gameObject.transform.position;
		playerHealth = 4;
	}

	//when health is gone, respawn player, otherwise lower the slider(healthpoints)
	public void Damage()
	{
		if (playerHealth == 0) 
			Application.LoadLevel (1);
		else 
			playerHealth--;
	}

	public void AddPoints()
	{
		score ++;
	}

	public void NextLevel()
	{
		StorePlayerValues ();
		Application.LoadLevel (Application.loadedLevel+1);
	}


	

}
