using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed);

        if (transform.position.x > 11.5f)
            transform.position = new Vector3(-11.4f, transform.position.y, transform.position.z);
        else if (transform.position.x < -11.5f)
            transform.position = new Vector3(11.4f, transform.position.y, transform.position.z);

        if (transform.position.y > 0f)
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        else if (transform.position.y < -4f)
            transform.position = new Vector3(transform.position.x, -4f, transform.position.z);
    }
}
