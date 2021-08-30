using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 1f;
    private float _canFire = 0f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + Vector3.up, Quaternion.identity);
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * _speed);

        if (transform.position.x > 11.5f)
            transform.position = new Vector3(-11.4f, transform.position.y, transform.position.z);
        else if (transform.position.x < -11.5f)
            transform.position = new Vector3(11.4f, transform.position.y, transform.position.z);

        if (transform.position.y > 0f)
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        else if (transform.position.y < -4f)
            transform.position = new Vector3(transform.position.x, -4f, transform.position.z);
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

        Debug.Log("Lives: " + _lives);
    }
}
