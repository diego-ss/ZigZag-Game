using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaPlataforma : MonoBehaviour
{
    [SerializeField]
    private float tamanhoPlataforma;
    [SerializeField]
    private GameObject plataforma;
    [SerializeField]
    private Vector3 posicaoInicial;


    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = plataforma.transform.position;
        tamanhoPlataforma = plataforma.transform.localScale.x;

        StartCoroutine(CriaChaoInGame());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CriaNoEixo(string eixo)
    {
        Vector3 tempPos = posicaoInicial;

        if(eixo == "X")
            tempPos.x += tamanhoPlataforma;
        else
            tempPos.z += tamanhoPlataforma;

        posicaoInicial = tempPos;
        Instantiate(plataforma, posicaoInicial, Quaternion.identity);
    }

    void CriaChaoXZ()
    {
        var temp = Random.Range(1, 10);

        if(temp <= 5)
        {
            CriaNoEixo("X");
        }
        else
        {
            CriaNoEixo("Z");
        }
    }

    IEnumerator CriaChaoInGame()
    {
        while(!BolaController.gameOver)
        {
            yield return new WaitForSeconds(0.5f);
            CriaChaoXZ();
        }
    }
}
