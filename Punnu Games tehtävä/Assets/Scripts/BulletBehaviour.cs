using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    [SerializeField] float bulletSpeed;


    void Update() {
        transform.Translate(Vector3.back * Time.deltaTime * bulletSpeed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerManager>().TakeDamage(5f, 5f, 10f);
            Debug.Log("Player took damage from bullet");
            GameObject.Find("Enemy").GetComponent<SimpleEnemy>().canShoot = true;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall")) {
            GameObject.Find("Enemy").GetComponent<SimpleEnemy>().canShoot = true;
            Destroy(gameObject);
        }
    }
}
