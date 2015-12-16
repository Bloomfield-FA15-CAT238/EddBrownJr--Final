using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour 
{


	public void OnTriggerEnter(Collider other)
	{
	
		if (other.gameObject.tag.Equals ("GamePlayers")) 
		{
			GameController gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
			gc.AddPoints();
			Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
