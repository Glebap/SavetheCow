using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private SpaceshipSpawn _spaceshipSpawn;
	[SerializeField] private RestartScript RestartScript;
	[SerializeField] private UIManager _uIManager;

	private bool _start = false;

	public bool CanStart()
	{
		return _start;
	}

	public void GameOver()
	{
		_spaceshipSpawn.StopSpawn();
		_uIManager.ShowUI();
		_uIManager.DisableTimer();
		StartCoroutine(RestartGame());
	}

	private void Update()
	{
		if (Input.touchCount > 0 && !_start)
		{
			StartGame();
		}
	}

	private void StartGame()
	{
		_start = true;
		_uIManager.HideUI();
		_spaceshipSpawn.StartSpawn();
	}

	private IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(1.5f);
		RestartScript.LoadGame();
	}
}
