using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
	[SerializeField] public int _damage = 1;
	[SerializeField] public int _health = 10;
    [SerializeField] private Transform _aim;
	[SerializeField] private Camera _camera;
	[SerializeField] private bool isImmortal = false;
	public bool isAlive;
	private Rigidbody2D _rb;


	Vector2 _movement;
	Vector3 _mousePos;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		isAlive = true;
	}

	private void Update()
	{
		_movement.x = Input.GetAxisRaw("Horizontal");
		_movement.y = Input.GetAxisRaw("Vertical");

		_mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

		if (isImmortal == false)
		{
			if (_health <= 0)
			{
				Die();
			}
		}
	}

	private void FixedUpdate()
	{
		_rb.MovePosition(_rb.position + _movement * _speed * Time.fixedDeltaTime);

		Vector3 lookDir = _mousePos - _aim.transform.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
		_aim.rotation = Quaternion.Euler(0,0,angle);
	}

	private void Die()
	{
		Destroy(gameObject);
		isAlive = false;
	}

	public void GetDamage(int damage)
	{
		_health -= damage;
	}
}
