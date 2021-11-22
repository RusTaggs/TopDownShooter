using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletForce = 20f;
	[SerializeField] private float bulletLifeTime = 3f;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

		StartCoroutine(Die());
	}

	IEnumerator Die()
	{
		yield return new WaitForSeconds(bulletLifeTime);
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}
}
