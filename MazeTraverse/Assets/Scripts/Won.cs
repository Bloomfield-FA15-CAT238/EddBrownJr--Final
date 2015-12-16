using UnityEngine;
using System.Collections;

public class Won : MonoBehaviour {

	public GameController controller;

	public void OnTriggerEnter(Collider intruder)
	{
		if (intruder.gameObject.tag.Equals ("GamePlayers"))
			controller.NextLevel();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
