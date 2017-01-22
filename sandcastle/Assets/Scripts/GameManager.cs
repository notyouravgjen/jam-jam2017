using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] destructiblePrefabs;
	public AudioSource[] countingSounds;
	public AudioSource splashSound;
	public GameObject spawnPoint;
	public AudioClip themeSong;

	public WaterLogs waterLogManager;

	private int currentRoundIndex;
	private GameObject currentRoundDestructible;

	public bool interactionDisabled;

	public static GameManager instance { get; private set; }

	public void Start()
	{
		if (instance == null)
		{
			instance = this;
		}

		//StartRound();
		Invoke("StartRound", 2.0f);
	}
	
	public void Update()
	{
	}

	private void EndRound()
	{
		this.interactionDisabled = true;

		if (this.currentRoundDestructible != null)
		{
			Destroy(this.currentRoundDestructible);
		}

		waterLogManager.Reset();

		// splash at the end of a level
		splashSound.Play();
	}

	private void StartRound()
	{
		GameObject prefab = destructiblePrefabs[currentRoundIndex];

		Vector3 pos = spawnPoint.transform.position;
		Quaternion rot = Quaternion.Euler(0, 0, 0);

		this.currentRoundDestructible = (GameObject)Instantiate(prefab, pos, rot, transform.parent);

		// play associated audio?
		if (this.countingSounds != null)
		{
			if (this.currentRoundIndex < this.countingSounds.Length)
			{
				this.countingSounds[currentRoundIndex].Play();
			}
		}

		this.interactionDisabled = false;
	}

	public void ProgressRound()
	{
		this.currentRoundIndex++;

		EndRound();

		if (this.currentRoundIndex < this.destructiblePrefabs.Length)
		{
			Invoke("StartRound", 3.0f);
			//StartRound();
		}
		else
		{
			// TODO: end of game logic here!
		}
	}
}
