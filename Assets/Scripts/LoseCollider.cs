using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {


	private LevelManager levelManager;
	
	void OnTriggerEnter2D(Collider2D trigger)
	{
		print ("It triggers me bro");
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		//Application.LoadLevel ("Win"); imo lepiej bo nie trzeba ^ public/private levelmanager ale idk
		levelManager.LoadLevel("Lose");
		
		Brick.breakableBrickCount = 0;
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("It just collide me");
	}
}
