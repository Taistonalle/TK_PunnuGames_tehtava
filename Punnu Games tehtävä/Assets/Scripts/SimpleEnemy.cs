using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {
    RaycastHit hit;
    [SerializeField] float rayLenght;
    [SerializeField] GameObject bulletPrefab;
    bool playerInFront; 
    public bool canShoot = true;


    void Update() {
        //Check if player is infront
        playerInFront = Physics.Raycast(transform.position, Vector3.back, out hit, rayLenght) && hit.rigidbody.CompareTag("Player");

        if (playerInFront && canShoot) {
            Shoot();
        }
        

    }

    void Shoot() {
        canShoot = false;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        Debug.Log("Enemy shot");
    }

    void OnDrawGizmos() {
        if (playerInFront) {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.back * rayLenght);
        }
        else {
            Gizmos.color = Color.white;
            Gizmos.DrawRay(transform.position, Vector3.back * rayLenght);
        }
    }
}
