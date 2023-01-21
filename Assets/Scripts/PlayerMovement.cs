using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    private float speed = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * 100 * Time.deltaTime;
        //rb.AddForce(movement);
        rb.velocity = movement;
    }
}
