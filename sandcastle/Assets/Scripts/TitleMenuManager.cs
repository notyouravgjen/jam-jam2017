using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuManager : MonoBehaviour {

	public AudioSource splashSound;
	public AudioSource music;

	private bool fadeMusic = false;
	private bool hasSplashed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Fade music and transition to next scene
		if (fadeMusic)
		{
			music.volume -= 0.01f;

			if (!hasSplashed && music.volume <= 0.75f)
			{
				splashSound.Play();
				hasSplashed = true;
			}

			if (music.volume <= 0)
			{
				fadeMusic = false;
				Invoke("PlayGame", 2.5f);
			}
		}
	}

	public void OnPlayClicked()
	{
		fadeMusic = true;
	}

	private void PlayGame()
	{
		SceneManager.LoadScene("Waves");
	}
}
