using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	bool gameStarted = false;
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameStarted == false)
		{
		this.transform.position = paddle.transform.position + paddleToBallVector;
				
			if (Input.GetMouseButtonDown(0))
			{
				print("Mouse clicked, launch ball");
				gameStarted = true;
				this.rigidbody2D.velocity = new Vector2 (1.5f, 10f);
			}
		}
		
	}
	
	
	void OnCollisionEnter2D(Collision2D col)
	{
	
		Vector2 tweak = new Vector2(Random.Range (0f, 0.3f), Random.Range(0f,0.3f));
		
		if (gameStarted)
		{
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}