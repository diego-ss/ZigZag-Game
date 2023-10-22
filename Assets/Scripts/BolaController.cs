﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 1.5f;
    [SerializeField]
#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    private Rigidbody rigidbody;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    [SerializeField]
    public static bool gameOver = false;
    [SerializeField]
    public static int moedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(velocidade, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            InverterMovimento();

        if(!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            gameOver = true;
            rigidbody.useGravity = true;
        }

        if (gameOver) 
            print("Game Over");

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        velocidade += 0.0001f;
    }

    void InverterMovimento()
    {
        if(rigidbody.velocity.x > 0)
            rigidbody.velocity = new Vector3(0, 0, velocidade);

        else if(rigidbody.velocity.z > 0)
            rigidbody.velocity = new Vector3(velocidade, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Moeda"))
        {
            moedas++;
            Destroy(other.gameObject);
            print(moedas);
        }
    }
}
