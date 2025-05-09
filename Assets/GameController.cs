using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
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
            if (!SceneManager.GetSceneByName("Menu").isLoaded)
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
        Time.timeScale = 1f;//reanude el tiempo del juego
        SceneManager.UnloadSceneAsync("Menu");
    }
}
