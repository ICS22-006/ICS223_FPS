using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    private float speed = 9.0f;
    private float horizInput;
    private float vertInput;
    private float gravity = -9.8f;

    private Vector3 movement;

    [SerializeField] private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);
        // Clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        // Add gravity
        movement.y = gravity;
        // take speed into account
        movement *= speed;
        // make movement processor independent
        movement *= Time.deltaTime;
        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
