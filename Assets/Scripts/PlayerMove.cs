using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private ParticleSystem _firstParticle;
	[SerializeField] private ParticleSystem _secondParticle;
	[SerializeField] private GameManager _gameManager;

	private Vector3 _touchPosition;
	private float _distanceBetween;
	private float _speed = 30f;
	private float _maxRange = 2.0f;
	private bool _move = true;

	private void Update()
	{
		if(_gameManager.CanStart() && _move && Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			_touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

			if(touch.phase == TouchPhase.Began)
			{
				_distanceBetween = _touchPosition.x - transform.position.x;
			}

			float NextPosition = _touchPosition.x - _distanceBetween;

			if (NextPosition >= -_maxRange && NextPosition <= _maxRange)
			{
				MoveX(NextPosition);
			}
			else
			{
				MoveX(Mathf.Sign(NextPosition)*_maxRange);
				_distanceBetween = _touchPosition.x - transform.position.x;                   
			}
		}
	}

	private void MoveX(float x)
		{
			transform.position = Vector2.MoveTowards (transform.position,
					new Vector2(x, transform.position.y), _speed * Time.deltaTime);
		}

	private void Death()
	{
		_firstParticle.Play();
		_secondParticle.Play();
		foreach(Collider2D c in GetComponents<Collider2D>()){c.enabled = false;}
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		_move = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Death();
			_gameManager.GameOver();
		}
	}
}
