using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 8f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _laserSpeed);
        if (transform.position.y > 8f)
            Destroy(gameObject);
    }
}
