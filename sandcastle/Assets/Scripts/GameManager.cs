using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] destructiblePrefabs;
	public AudioSource[] countingSounds;
	public GameObject spawnPoint;
	public AudioClip themeSong;

	private int currentRoundIndex;
	private GameObject currentRoundDestructible;

	public void Start()
	{
		StartRound();
	}
	
	public void Update()
	{
		// TEST ROUND PROGRESSION
		if (Input.GetKeyDown(KeyCode.A))
		{
			ProgressRound();
		}
	}

	private void StartRound()
	{
		GameObject prefab = destructiblePrefabs[currentRoundIndex];

		Vector3 pos = spawnPoint.transform.position;
		Quaternion rot = Quaternion.Euler(0, 0, 0);

		if (this.currentRoundDestructible != null)
		{
			Destroy(this.currentRoundDestructible);
		}

		this.currentRoundDestructible = (GameObject)Instantiate(prefab, pos, rot, transform.parent);

		// play associated audio?
		if (this.countingSounds != null)
		{
			if (this.currentRoundIndex < this.countingSounds.Length)
			{
				this.countingSounds[currentRoundIndex].Play();
			}
		}
	}

	private void ProgressRound()
	{
		this.currentRoundIndex++;

		if (this.currentRoundIndex < this.destructiblePrefabs.Length)
		{
			StartRound();
		}
	}
}
