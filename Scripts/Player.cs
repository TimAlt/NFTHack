using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float hInput;
    private float vInput;
    private float startSpeed;

    public float moveForce;

    public GameObject bullet;
    public Transform weapon;
    public GameObject explosion;

    private const float fireRate = .075f;
    private float timeSinceLastBullet = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startSpeed = moveForce;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        timeSinceLastBullet += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") >= 1)
        {
            moveForce = startSpeed / 4f;
            if (timeSinceLastBullet >= fireRate)
            {
                timeSinceLastBullet = 0;
                Fire();
            }
        }
        else
        {
            moveForce = startSpeed;
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(-vInput, 0, hInput).normalized;
        rb.AddForce(moveVector * moveForce * Time.fixedDeltaTime);
    }

    void Fire()
    {
        Instantiate(bullet, weapon.position, weapon.rotation);

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
