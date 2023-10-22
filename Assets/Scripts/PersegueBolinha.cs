using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersegueBolinha : MonoBehaviour
{
    [SerializeField]
    private Transform bolinha;
    [SerializeField]
    private Vector3 distancia;
    [SerializeField]
    private float lerpValue;
    [SerializeField]
    private Vector3 posicaoCamera, posicaoAlvo;

    // Start is called before the first frame update
    void Start()
    {
        posicaoCamera = transform.position;
        posicaoAlvo = bolinha.position;
        distancia = posicaoAlvo - posicaoCamera;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if(!BolaController.gameOver)
            Perseguir();
    }

    private void Perseguir()
    {
        posicaoAlvo = bolinha.position;
        posicaoCamera = Vector3.Lerp(posicaoCamera, posicaoAlvo - distancia, lerpValue);
        transform.position = posicaoCamera;
    }
}
