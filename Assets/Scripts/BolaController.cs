using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.2f;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private bool gameOver = false;

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
            gameOver = true;

        if(gameOver) 
            print("Game Over");

        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }

    void InverterMovimento()
    {
        if(rigidbody.velocity.x > 0)
            rigidbody.velocity = new Vector3(0, 0, velocidade);

        else if(rigidbody.velocity.z > 0)
            rigidbody.velocity = new Vector3(velocidade, 0, 0);

    }
}
