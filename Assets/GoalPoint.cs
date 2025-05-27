using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //pasar al siguiente nivel
            //SceneManager.LoadScene("Nivel2");

            GameController.Instance.SiguienteNivel();
        }
    }
}
