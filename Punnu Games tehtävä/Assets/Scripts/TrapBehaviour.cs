using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerManager>().TakeDamage(5f, 5f, 10f);
            Debug.Log("Player took damage from trap");
        }
    }
}
