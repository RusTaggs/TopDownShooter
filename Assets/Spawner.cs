using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
	[SerializeField] private bool spawnEnemies = false;

	private Player player;
	private bool isPlayerAlive;

	private void Start()
	{
		player = FindObjectOfType<Player>().GetComponent<Player>();

		if (spawnEnemies)
		{
			StartCoroutine(Spawn());
		}
	}

	private void Update()
	{
		isPlayerAlive = player.isAlive;
	}

	IEnumerator Spawn()
	{
		
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(2, 5));
			GameObject obj = prefabs[Random.Range(0, prefabs.Length)];

			if (isPlayerAlive)
			{
				Instantiate(obj, transform.position, Quaternion.identity);
			}

			yield return new WaitForSeconds(2);
		}
		
	}
}
