using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _damage = 2;
	[SerializeField] private float _distance = 1f;
	[SerializeField] private bool _enableAI = true;
	[SerializeField] private GameObject[] powerUps;
	[SerializeField] private int powerChanse = 50;

    [SerializeField] private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
		if (_health <= 0)
		{
            Die();
		}

		if (_enableAI)
		{
			if (_player != null)
			{
				if (Vector2.Distance(transform.position, _player.transform.position) > _distance)
				{
					transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
				}
			}
		}
    }

    private void Die()
	{
        Destroy(gameObject);
		int rand = Random.Range(0, 100);

		if (rand <= powerChanse)
		{
			Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, Quaternion.identity);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Bullet")
		{
            _health -= _player._damage;
		}

		if (collision.collider.tag == "Player")
		{
			_player.GetDamage(_damage);
		}
	}

}
