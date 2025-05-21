using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI opcion1;
    private bool esMenuInicio = false;

    private void Start()
    {
        esMenuInicio = SceneManager.GetSceneByName("MenuInicio").isLoaded;

        if (!esMenuInicio)
        {
            opcion1.text = "Regresar";
        }
    }
    public void IniciarJuego()
    {
        if (esMenuInicio)
        {
            print("Inciando juego");
            SceneManager.LoadScene("Nivel1");
        }
        else
        {
            GameController.Instance.RegresarJuego();
        }
    }

    public void SalirJuego()
    {
        Debug.LogWarning("Saliendo del juego");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ActivarConfigSonido()
    {
        //sacamos la escena de menu
        SceneManager.UnloadSceneAsync("Menu");
        //activamos la escena de menu sonido
        SceneManager.LoadScene("MenuSonido", LoadSceneMode.Additive);
    }
}
