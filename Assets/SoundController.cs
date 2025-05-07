using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance { get; private set; } = null;

    private void Awake()
    {
        //verifico si el objeto en cuestion SoundController es un duplicado innecesario o no
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //Evita que se elimine el SoundController al cambiar de escena
            DontDestroyOnLoad(this);
        }
    }
}
