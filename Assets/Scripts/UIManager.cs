using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] private GameObject _startText;
	[SerializeField] private GameObject _gameOverText;
	[SerializeField] private Text _timerText;

	private bool _setUpTimer = false;
	private float _secondsCount;

	public void HideUI()
	{
		StartCoroutine(HideStartUI());
		StartCoroutine(ShowTimerUI());
	}

	public void ShowUI()
	{
		StartCoroutine(ShowGameOverUI());
	}

	public int GetSecondsPassed()
	{
		return (int)_secondsCount;
	}

	public void DisableTimer()
	{
		_setUpTimer = false;
	}

	private void Update()
	{
		if (_setUpTimer)
		{
			UpdateTimerUI();
		}
	}

	private void UpdateTimerUI()
	{
		_secondsCount += Time.deltaTime;
		_timerText.text = ((int)_secondsCount).ToString ();
	}

	private IEnumerator HideStartUI()
	{
		float t = 0.0f;
		while (t < 1)
		{
			t += Time.deltaTime / 60f;
			_startText.transform.localPosition = Vector3.Lerp(_startText.transform.localPosition, new Vector3(_startText.transform.localPosition.x, 200.0f, 0.0f), t);
			yield return null;
		}
		_startText.SetActive(false);
	}

	private IEnumerator ShowTimerUI()
	{
		Color _timerColor = _timerText.color;
		_timerColor.a = 1.0f;
		float t = 0.0f;
		while (_timerText.color != _timerColor)
		{
			t += Time.deltaTime;
			_timerText.color = Color.Lerp(_timerText.color, _timerColor, t);
			yield return null;
		}
		_setUpTimer = true;
	}

	private IEnumerator ShowGameOverUI()
	{
		float t = 0.0f;
		while (t < 1)
		{
			t += Time.deltaTime / 60f;
			_gameOverText.transform.localScale = Vector3.Lerp(_gameOverText.transform.localScale, new Vector3(1.0f, 1.0f, 1.0f), t);
			yield return null;
		}
	}
}
