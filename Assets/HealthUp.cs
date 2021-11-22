using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private int healthUp = 2;
    [SerializeField] private Player player;

	private void Start()
	{
		player = FindObjectOfType<Player>().GetComponent<Player>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			player._health += healthUp;
			Destroy(gameObject);
		}
	}
}
