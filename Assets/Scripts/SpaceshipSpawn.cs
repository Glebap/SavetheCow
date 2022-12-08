using System.Collections;
using UnityEngine;

public class SpaceshipSpawn : MonoBehaviour
{
	[SerializeField] private GameObject _spaceshipPrefab;
	[SerializeField] private Sprite[] _spaceshipSkins;
	[SerializeField] private UIManager _uIManager;
	[SerializeField] private float _minSpawnInterval = 0.25f;

	private float _spawnInterval;
	private float _spawnHeight;
	private SpriteRenderer spriteRenderer;
	private int _secondsPassed;

	public void StartSpawn()
	{
		_spawnInterval = 1.4f;
		StartCoroutine(spawnSpaceship(_spawnInterval));

	}

	public void StopSpawn()
	{
		StopAllCoroutines();
	}

	private IEnumerator spawnSpaceship(float interval)
	{
		yield return new WaitForSeconds(interval);

		_spawnHeight = -Camera.main.ScreenToWorldPoint(Vector2.zero).y + 0.5f;
		SpawnEnemy();
		if (_uIManager.GetSecondsPassed()%2 == 0)
		{
			interval = _minSpawnInterval + _spawnInterval - Mathf.Pow(_uIManager.GetSecondsPassed()/2, 0.5f) * 0.2f;
		}
		StartCoroutine(spawnSpaceship(interval));
	}

	private void SpawnEnemy()
	{
		GameObject enemy = Instantiate(_spaceshipPrefab, 
			new Vector3(Random.Range(-10f, 10f)*0.2f, _spawnHeight, 0.0f),Quaternion.identity);
		spriteRenderer = enemy.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = _spaceshipSkins[Random.Range(0, _spaceshipSkins.Length)];
	}
}
