using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochete : MonoBehaviour
{
    [SerializeField]
    private int valorPontuacao;
    [SerializeField]
    private int forcaRicochete;
    [SerializeField]
    private AudioSource sound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 angulo = (collision.gameObject.transform.position - transform.position).normalized;
            enemyRigidBody.AddForce(angulo * forcaRicochete, ForceMode.VelocityChange);
            GameController.Instance.scoreAtual += valorPontuacao;
            sound.Play();
        }
    }

   
}
