using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] destructiblePrefabs;
	public GameObject fatherObject;
	public AudioSource[] countingSounds;
	public AudioSource splashSound;
	public GameObject spawnPoint;
	public TextMesh levelLabel;

	public FadeableMusic mainMusic;

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

		this.interactionDisabled = true;

		// SHOW SCRIPTED EVENTS...

		// Dad
		ScriptedEvents.instance.ShowNextScript();

		// DESTROY THE BALL
		Invoke("ShowNextScript", 5.0f);

		// Press space
		Invoke("ShowNextScript", 10.0f);

		// hide scripted events and proceed
		Invoke("HideScriptedEvent", 15.0f);

		levelLabel.text = "Level " + (currentRoundIndex+1);
		Invoke("ShowLevelLabel", 15.0f);

		//StartRound();
		Invoke("StartRound", 17.0f);
	}

	private void EndRound()
	{
		this.interactionDisabled = true;

		if (this.currentRoundDestructible != null)
		{
			Destroy(this.currentRoundDestructible);
		}

		// WRECKED
		ShowNextScript();
		// Dad outro
		Invoke("ShowNextScript", 5.0f);
		// hide scripted events and proceed
		Invoke("HideScriptedEvent", 10.0f);

		waterLogManager.Reset();

		mainMusic.SetFadeTarget(0.25f);

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

		mainMusic.SetFadeTarget(1.0f);

		this.interactionDisabled = false;

		Invoke("HideLevelLabel", 4.0f);
	}

	void Update()
	{
		/*if (Input.GetKeyDown(KeyCode.A))
		{
			ProgressRound();
		}*/
	}

	public void ProgressRound()
	{
		this.currentRoundIndex++;

		EndRound();

		if (this.currentRoundIndex < this.destructiblePrefabs.Length)
		{
			levelLabel.text = "Level " + (currentRoundIndex+1);
			Invoke("ShowLevelLabel", 8.0f);

			Invoke("StartRound", 10.0f);
		}
		else
		{
			Invoke("EndGame", 2.0f);
		}
	}

	public void ShowLevelLabel()
	{
		levelLabel.gameObject.SetActive(true);
	}

	public void HideLevelLabel()
	{
		levelLabel.gameObject.SetActive(false);
	}

	private void EndGame()
	{
		// End of game logic: dad shows up! - no, nevermind
		mainMusic.SetFadeTarget(0.25f);
		//fatherObject.SetActive(true);
	}

	private void ShowNextScript()
	{
		ScriptedEvents.instance.ShowNextScript();
	}

	private void HideScriptedEvent()
	{
		ScriptedEvents.instance.HideCurrentScript();
	}
}
