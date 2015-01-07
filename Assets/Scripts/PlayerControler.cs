using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayerControler : MonoBehaviour
{
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    public float speed;
    public float tilt;
    public float fireRate = 0.5f;

    private float nextFire = 0f;

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            rigidbody.position.y,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}
