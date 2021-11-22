using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
	[SerializeField] public float fireRate = 1f;
	private float lastFired;
	

	private void Update()
	{

		if (Input.GetMouseButton(0))
		{
			if (Time.time - lastFired > 1 / fireRate)
			{
				lastFired = Time.time;
				Instantiate(bulletPref, transform.position, transform.rotation);
			}
		}
		
	}

	
}
