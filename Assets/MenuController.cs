using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void IniciarJuego()
    {
        print("Inciando juego");
        SceneManager.LoadScene("Nivel1");
    }

    public void SalirJuego()
    {
        Debug.LogWarning("Saliendo del juego");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
