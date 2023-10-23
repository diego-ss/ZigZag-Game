using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaController : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 1.5f, limiteVelocidade = 2.7f;
    [SerializeField]
#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    private Rigidbody rigidbody;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    [SerializeField]
    public static bool gameOver = false;
    [SerializeField]
    public static int moedas = 0;

    public Text velocidadeText;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(velocidade, 0, 0);
        StartCoroutine(AjustaVelocidade());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
            InverterMovimento();

        if(!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            gameOver = true;
            rigidbody.useGravity = true;
        }

        if (gameOver) 
            print("Game Over");

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        velocidadeText.text = velocidade.ToString();
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

    IEnumerator AjustaVelocidade()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(1.3f);

            if(velocidade < limiteVelocidade)
                velocidade += 0.1f;
        }
    }
}
