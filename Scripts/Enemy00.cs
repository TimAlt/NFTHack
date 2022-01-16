using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy00 : MonoBehaviour
{
    private Rigidbody rb;

    public float moveForce;

    public GameObject bullet;
    public Transform weapon;
    public GameObject explosion;

    private const float zLimit = 110f;

    private float attackInterval = 2f;
    private float timeSinceLastBullet = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attackInterval = Random.Range(1.2f, 2.3f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * moveForce * Time.fixedDeltaTime);
        if (transform.position.z < zLimit && transform.position.z > 0f)
        {
            timeSinceLastBullet += Time.fixedDeltaTime;
            if (timeSinceLastBullet > attackInterval)
            {
                timeSinceLastBullet = 0;
                Fire();
            }
        }
    }

    private void Fire()
    {
        Instantiate(bullet, weapon.position, weapon.rotation);
        attackInterval = Random.Range(1.2f, 2.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
