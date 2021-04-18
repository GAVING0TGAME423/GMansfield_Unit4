using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody Enemyrb;
    GameObject player;
    public float speed = 4;

    void Start()
    {
        player = GameObject.Find("Player");
       Enemyrb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Vector3 SeekDirection = (player.transform.position - transform.position).normalized;
        Enemyrb.AddForce(SeekDirection * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
