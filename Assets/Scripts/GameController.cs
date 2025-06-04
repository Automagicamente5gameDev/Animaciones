using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private const int NIVEL_FINAL = 2;
    private const string NOMBRE_NIVEL = "Nivel";
    private int nivel = 1;
    private TextMeshProUGUI msjFinal = null;
    public static GameController Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += BuscarMsjFinalAlCargarEscena;

        //evaluar si estoy comenzando en el nivel final
        string escenaNombre = SceneManager.GetActiveScene().name; // Nivel1 - Nivel2 - NivelN
        if (escenaNombre != "MenuInicio")
        {
            string nivelActual = new string(escenaNombre.Where(char.IsDigit).ToArray());// 1 - 2 - N
            nivel = int.Parse(nivelActual);
            Debug.LogWarning("Nivel actual es: " + nivel);
            BuscarMsjFinal();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.sceneCount <= 1)
            {
                Time.timeScale = 0f;//detenga el tiempo del juego
                SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            }
            else
            {
                RegresarJuego();
            }
        }
    }

    public void RegresarJuego()
    {
        int cantEscenas = SceneManager.sceneCount;//pido la cantidad de escenas activas (0-N)
        Scene sceneTemp;

        for (int i = 0; i < cantEscenas; i++)
        {
            sceneTemp = SceneManager.GetSceneAt(i);//asignar a sceneTemp una escena activa a la vez
            if (sceneTemp.name != (NOMBRE_NIVEL+nivel))
            {
                SceneManager.UnloadSceneAsync(sceneTemp);
                Debug.LogWarning("Eliminando escena: "+ sceneTemp.name);
            }
        }

        Time.timeScale = 1f;//reanude el tiempo del juego
    }

    public void SiguienteNivel()
    {
        nivel++;
        SceneManager.LoadScene( (NOMBRE_NIVEL + nivel) );
        
    }

    public void BuscarMsjFinalAlCargarEscena(Scene scene, LoadSceneMode mode)
    {
        BuscarMsjFinal();
    }

    private void BuscarMsjFinal()
    {
        if (nivel == NIVEL_FINAL)
        {
            msjFinal = GameObject.FindGameObjectWithTag("MsjFinal").GetComponent<TextMeshProUGUI>();
            Debug.LogWarning(msjFinal);
            SceneManager.sceneLoaded -= BuscarMsjFinalAlCargarEscena;
        }
    }

    public void JuegoTerminado()
    {
        msjFinal.text = "GANASTE!";
        msjFinal.enabled = true;
    }
}
