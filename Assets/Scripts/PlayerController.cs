using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* ToDo
     - get player to move left, right, jump 
     - lasso interaction
     */
     
     public float horizontalInput;
     public float verticalInput;
     private Rigidbody playerRb;
     public float speed = 10f;
     public float turnspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
      playerRb  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, horizontalInput * turnspeed * Time.deltaTime);

        playerRb.AddForce(transform.forward * verticalInput * Time.deltaTime * speed);
    }
}
