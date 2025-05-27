using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private const string NOMBRE_NIVEL = "Nivel";
    private int nivel = 1;
    public static GameController Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
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
}
