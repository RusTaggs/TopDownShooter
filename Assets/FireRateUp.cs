using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUp : MonoBehaviour
{
    [SerializeField] private float fireUp = 2f;

    [SerializeField] private Shooting shoot;
    void Start()
    {
        shoot = FindObjectOfType<Shooting>().GetComponent<Shooting>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
            shoot.fireRate += fireUp;
            Destroy(gameObject);
		}
	}

}
