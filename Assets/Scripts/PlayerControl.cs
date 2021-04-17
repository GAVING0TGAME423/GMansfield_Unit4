using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody RBPlayer;
    public float speed = 10;
    private GameObject FocalPoint;
    Renderer rendererplayer;

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
    }
}
