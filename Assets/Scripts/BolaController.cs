using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
    [SerializeField]
    public Text txtMoedas;
    [SerializeField]
    private GameObject particulasMoedas;

    // Variáveis GameOver
    [SerializeField]
    private Text txtBtn, txtGo;
    [SerializeField]
    private Image imgBtn, imgFundo;
    [SerializeField]
    private bool showGameOver = false;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene cena, LoadSceneMode modo)
    {
        gameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        moedas = PlayerPrefs.GetInt("NumeroMoedas");
        txtMoedas.text = moedas.ToString();

        rigidbody.velocity = new Vector3(velocidade, 0, 0);
        StartCoroutine(AjustaVelocidade());

        showGameOver = true;
        txtBtn.enabled = false;
        txtGo.enabled = false;
        imgBtn.enabled = false;
        imgFundo.enabled = false;
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

        if (gameOver && showGameOver)
        {
            PlayerPrefs.SetInt("NumeroMoedas", moedas);
            txtBtn.enabled = true;
            txtGo.enabled = true;
            imgBtn.enabled = true;
            imgFundo.enabled = true;
            showGameOver = false;
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        //velocidadeText.text = velocidade.ToString();
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
            txtMoedas.text = moedas.ToString();
            Instantiate(particulasMoedas, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
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

    public void JogarNovamente()
    {
        SceneManager.LoadScene(0);
    }
}
