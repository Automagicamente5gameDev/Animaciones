using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private const int MAX_VIDAS = 3;
    Rigidbody2D rbJugador;
    bool isGrounded;
    bool attack;
    Animator animationPlayer;
    private bool bajoAtaque = false;
    private int vidas = MAX_VIDAS;
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private Transform nuevoRespawn = null;
    private Vector3 respawnPosition;

    //SerializedField usado para permitir asignar una barra de vida externa desde el editor de unity
    [SerializeField] private VidaUIControlador controladorVida = null;


    public int getVida()
    {
        return vidas;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (nuevoRespawn == null)
        {
            respawnPosition = transform.position;
        }
        else
        {
            respawnPosition = nuevoRespawn.position;
        }
            rbJugador = GetComponent<Rigidbody2D>();
        animationPlayer = GetComponent<Animator>();

        //si controladorVida no fue asignado en el editor entonces se busca una barra de vida dentro del objeto jugador
        if (!controladorVida)
        {
            //busca el script VidaUIControlador en el objeto actual y los objetos internos del mismo
            controladorVida = GetComponentInChildren<VidaUIControlador>();
        }
        controladorVida.SetVidaTotal(vidas);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bajoAtaque)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rbJugador.linearVelocityY = fuerzaSalto;
                isGrounded = false;
                SoundFXController.Instance.JugadorSalto(transform);
            }
            else if (Input.GetAxis("Horizontal") != 0 && Input.GetAxisRaw("Horizontal") != 0)
            {
                rbJugador.linearVelocityX = 5f * Input.GetAxis("Horizontal");

                //voltea el objeto jugador entero usando localScale - gira TODO
                //transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
                GetComponent<SpriteRenderer>().flipX = Input.GetAxisRaw("Horizontal") == 1;
            }

            if (Input.GetAxis("Horizontal") == 0 || !isGrounded)
            {
                SoundFXController.Instance.JugadorCaminar();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                attack = true;
                SoundFXController.Instance.JugadorAtaque(transform);

            }
        }
        animationPlayer.SetFloat("movement", Mathf.Abs(Input.GetAxis("Horizontal")));
        animationPlayer.SetBool("isGrounded", isGrounded);
        animationPlayer.SetBool("attack", attack);
    }

    public void StopAttack()
    {
        attack = false;
    }

    // Detecta si el jugador esta tocando el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Asegarate de que el suelo tenga el tag "Ground"
        {
            isGrounded = true;
            bajoAtaque = false;
        }
    }

    public void serAtacado(Vector2 empuje)
    {
        bajoAtaque = true;
        rbJugador.linearVelocity = empuje;
        isGrounded = false;
        vidas--;
        SoundFXController.Instance.JugadorHerido(transform);

        if (vidas <= 0)
        {
            Derrota();
        }

        //acciona el comportamiento actualizar vida del controladorVida
        controladorVida.ActualizarVida(vidas);
        animationPlayer.SetTrigger("danio");
        SoundFXController.Instance.JugadorCaminar();
    }

    public void IniciarSonidoCaminar()
    {
        SoundFXController.Instance.JugadorCaminar(transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LimiteMapa"))
        {
            Derrota();
            isGrounded = false;
            controladorVida.ActualizarVida(vidas);
        }
        else if (collision.CompareTag("PuntoGuardado"))
        {
            respawnPosition = collision.transform.position;
        }
    }

    private void Derrota()
    {
        SoundFXController.Instance.JugadorDerrota(transform);
        
        //Destroy(gameObject);
        transform.position = respawnPosition;
        rbJugador.linearVelocity = Vector2.zero;
        vidas = MAX_VIDAS;
    }
}