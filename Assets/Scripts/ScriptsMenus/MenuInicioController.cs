using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicioController : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
