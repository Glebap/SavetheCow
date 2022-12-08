using UnityEngine;

public class FallDown : MonoBehaviour
{
	[SerializeField] private float _fallSpeed = 4.0f;
	[SerializeField] private ParticleSystem _particleSystem;

	private bool _move = true;

	private void Update()
	{
		if(_move)
		{
			transform.position -= new Vector3 (0, _fallSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Ground")
		{
			Explode();
		}
	}

	void Explode()
	{
		_particleSystem.Play();
		_move = false;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<Collider2D>().enabled = false;
		Destroy(gameObject,0.75f);
	}
}
