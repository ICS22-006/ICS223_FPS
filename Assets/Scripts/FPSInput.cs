using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    private float speed = 9.0f;
    private float horizInput;
    private float vertInput;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        movement = new Vector3(horizInput, 0, vertInput) * Time.deltaTime * speed;
        transform.Translate(movement, Space.Self);
    }
}
