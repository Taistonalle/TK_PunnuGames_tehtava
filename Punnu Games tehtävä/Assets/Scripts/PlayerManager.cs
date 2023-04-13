using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    [SerializeField] Slider hpBar;
    float visualHealth;

    [SerializeField] float health;
    public float Health {
        get {
            return health;
        }
        set {
            health = value;
        }
    }

    void Start() {
        hpBar.maxValue = health;
        visualHealth = health;
        hpBar.value = visualHealth;
    }

    void Update() {
        hpBar.value = visualHealth;

        ////Debug test button
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    //TakeDamage(5, 5f);
        //    StartCoroutine(TakeDamageExtra(5f, 5f, 10f));
        //}
    }

    public void TakeDamage(float damage, float time, float timerSpeed) {
        Health -= damage;
        StartCoroutine(UpdateHpBar(damage, time, timerSpeed));
    }

    IEnumerator UpdateHpBar(float damage, float time, float timerSpeed) {
        visualHealth = Mathf.Clamp(visualHealth, visualHealth - damage, visualHealth);
        while (visualHealth > visualHealth - damage && time > 0) {
            visualHealth -= Time.deltaTime * timerSpeed;
            time -= Time.deltaTime * timerSpeed;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        visualHealth = Mathf.RoundToInt(Health);
    }
}

