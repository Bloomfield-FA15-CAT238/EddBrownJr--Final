using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour 
{

	private AIBehavior state = AIBehavior.Roam;
	static private List<GameObject> patrolPoints = null;
	private GameObject patrollingInterestPoint;
	public float moveSpeed = 3.0f;
	public float step;
	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		step = moveSpeed * Time.deltaTime;
		if (patrolPoints == null) 
		{
			patrolPoints = new List<GameObject> ();
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("PatrolPoints"))
				patrolPoints.Add (go);
		}
		SwitchRoam ();
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		switch(state)
		{
			case AIBehavior.Roam:
				OnRoamUpdate();
				break;
			case AIBehavior.Chase:
				OnChaseUpdate();
				break;
		}
	
	}

	//Paces back and forth
	void OnRoamUpdate()
	{

		transform.position = Vector3.MoveTowards (transform.position, patrollingInterestPoint.transform.position, step); 
		float distance = Vector3.Distance(transform.position, patrollingInterestPoint.transform.position);
		if (distance == 0)
			FindPatrolPoint ();
	}

	void OnChaseUpdate()
	{
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
	}

	void SwitchRoam()
	{
		state = AIBehavior.Roam;
		FindPatrolPoint ();
	}

	void SwitchChase(GameObject target)
	{
		state = AIBehavior.Chase;
		player = target;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.Equals(GameObject.FindWithTag("GamePlayers")))
			SwitchChase(other.gameObject);

	}

	void FindPatrolPoint()
	{
		int choice = Random.Range (0, patrolPoints.Count);
		patrollingInterestPoint = patrolPoints [choice];
	}


}
