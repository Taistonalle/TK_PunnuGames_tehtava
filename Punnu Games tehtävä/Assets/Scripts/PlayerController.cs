using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float speed;
    float horizontalInput, verticalInput;
    Rigidbody rb;
    Bounds colliderBounds;
    RaycastHit hitF, hitB, hitL, hitR;

    void Start() {
        rb = GetComponent<Rigidbody>();
        colliderBounds = GetComponent<CapsuleCollider>().bounds;  
    }

    void Update() {
        //Get inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        Move();
    }

    //Prevent player sliding after colliding with walls by reseting velocity value to zero
    void OnCollisionExit(Collision collision) {
        if (collision.collider.CompareTag("Wall")) {
            rb.velocity = Vector3.zero;
        }
    }

    void Move() {
        //Checks if player is moving to "x" direction
        bool downMovement = verticalInput < 0f;
        bool upMovement = verticalInput > 0f;
        bool leftMovement = horizontalInput < 0f;
        bool rightMovement = horizontalInput > 0f;

        //Wall touch checks
        bool wallTouchF = Physics.Raycast(transform.position, Vector3.forward, out hitF, colliderBounds.size.z / 2);
        bool wallTouchB = Physics.Raycast(transform.position, Vector3.back, out hitB, colliderBounds.size.z / 2);
        bool wallTouchL = Physics.Raycast(transform.position, Vector3.left, out hitL, colliderBounds.size.z / 2);
        bool wallTouchR = Physics.Raycast(transform.position, Vector3.right, out hitR, colliderBounds.size.z / 2);

        //Disable movement direction if hitting a wall, otherwise move normally.
        if (wallTouchB && hitB.collider.CompareTag("Wall") && downMovement || 
            upMovement && wallTouchF && hitF.collider.CompareTag("Wall")) transform.Translate(new Vector3(horizontalInput, 0f, 0f) * Time.deltaTime * speed);
        else if (wallTouchL && hitL.collider.CompareTag("Wall") && leftMovement || 
            rightMovement && wallTouchR && hitR.collider.CompareTag("Wall")) transform.Translate(new Vector3(0f, 0f, verticalInput) * Time.deltaTime * speed);
        else transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed);
    }
}
