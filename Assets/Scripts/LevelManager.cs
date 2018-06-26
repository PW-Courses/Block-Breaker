﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel (string name)
	{
		Application.LoadLevel (name);
	}
	
	public void LoadNextLevel ()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	public void QuitGame ()
	{
		Application.Quit ();
	}
	
	public void BricksDestroyed()
	{
		if(Brick.breakableBrickCount <= 0)
		{
			LoadNextLevel();
		}
	}
}
