using System.Collections;

using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;


}
public class PlayerController : MonoBehaviour
{
    public Boundary bound;
    private Rigidbody rb;
    public float tilt;
    public float speed;
    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate;
    private float nextFire;
    private AudioSource audio;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float moveHorizontal =Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(

            Mathf.Clamp(rb.position.x, bound.xMin, bound.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, bound.zMin, bound.zMax)

            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tilt);   // or replace tilt with minus tilt but the public tilt value must be positive then


      

    }


    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;

            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();

            /*Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); for mouse

transform.position = Vector3.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);﻿ */


        }



    }
}
