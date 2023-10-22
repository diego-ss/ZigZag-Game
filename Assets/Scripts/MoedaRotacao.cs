using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedaRotacao : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 75;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, velocidade * Time.deltaTime));
    }
}
