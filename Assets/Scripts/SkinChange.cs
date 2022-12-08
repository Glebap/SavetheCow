using UnityEngine;

public class SkinChange : MonoBehaviour
{
	[SerializeField] private Sprite[] _playerSkins;

	private SpriteRenderer _spriteRenderer;

	private void Start()
	{
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		SetUpSkin();
	}

	private void SetUpSkin()
	{
		_spriteRenderer.sprite = _playerSkins[Random.Range(0, _playerSkins.Length)];
	}
}
