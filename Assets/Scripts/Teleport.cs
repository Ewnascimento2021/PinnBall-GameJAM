using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform otherTunnel;

    [SerializeField]
    private Rigidbody ball;

    [SerializeField]
    private AudioSource soundTP;

    private void Update()
    {
        if(GameController.Instance.isTeleporting)
        {
            if(Time.time - GameController.Instance.lastTimeStamp >= 1.5f )
            {
                ball.transform.position = otherTunnel.transform.position;
                soundTP.Play();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject == ball.gameObject) && !GameController.Instance.isTeleporting)
        {
            GameController.Instance.isTeleporting = true;
            GameController.Instance.lastTimeStamp = Time.time;
            other.transform.position = new Vector3(0, -30, 0);

            soundTP.Play();
        }



    }
}
