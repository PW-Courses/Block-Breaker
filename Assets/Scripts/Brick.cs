using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public AudioClip boing;
	public Sprite[] hitSprites;
	public static int breakableBrickCount = 0;
	public GameObject smoke;
	public GameObject puff;
	
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	

	// Use this for initialization
	void Start ()
	{	
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks 
		if (isBreakable) {
			breakableBrickCount++;	
		}
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint (boing, transform.position, 0.01f);
		if (isBreakable) {
			HandleHits ();
		}
		//SimulateWin();
	}
	
	void HandleHits ()
	{
		timesHit = timesHit + 1;
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) {
			breakableBrickCount--;
			print (breakableBrickCount);
			levelManager.BricksDestroyed (); 
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, (gameObject.transform.position), Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = new Vector4 ( gameObject.GetComponent<SpriteRenderer>().color.r, 
															gameObject.GetComponent<SpriteRenderer>().color.g,
		                                                    gameObject.GetComponent<SpriteRenderer>().color.b,
		                                                    0.3f);
	}
	
		

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Block sprite missing!");
		}	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	
}
