using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody RBPlayer;
    public float speed = 10;
    private GameObject FocalPoint;
    Renderer rendererplayer;
    bool haspowerup = false;
    public float powerupspeed = 10;
    public GameObject PowerupIndicator;

    void Start()
    {
       RBPlayer = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find ("Focal Point");
        rendererplayer = GetComponent<Renderer>();
    }

    
    void Update()
    {
        float ForwardInput = Input.GetAxis("Vertical");
        float magnitude = ForwardInput * speed * Time.deltaTime;
        RBPlayer.AddForce(FocalPoint.transform.forward * magnitude , ForceMode.Impulse);

        if(ForwardInput > 0)
        {
            rendererplayer.material.color = new Color(1 - ForwardInput, 1, 1 - ForwardInput);
        }
       else
        {
            rendererplayer.material.color = new Color(1 + ForwardInput, 1, 1 + ForwardInput);
        }
        PowerupIndicator.transform.position = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power Up"))
        {
            haspowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            PowerupIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (haspowerup && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with" + collision.gameObject + "with power up set to" + haspowerup);
            Rigidbody EnemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayDirection = collision.gameObject.transform.position - transform.position;

            EnemyRB.AddForce(AwayDirection * powerupspeed, ForceMode.Impulse);
            
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);
        haspowerup = false;
        PowerupIndicator.SetActive(false);
    }
}
