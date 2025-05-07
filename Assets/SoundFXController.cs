using UnityEngine;

public class SoundFXController : MonoBehaviour
{
    public static SoundFXController Instance { get; private set; } = null;
    [SerializeField] private AudioSource prefabAudioSource;
    [Header("\t\t\t---Jugador---")]
    [SerializeField] private AudioClip clipJugadorSalto;
    [SerializeField] private AudioClip clipJugadorHerido;
    [SerializeField] private AudioClip clipJugadorAtaque;
    [SerializeField] private AudioClip clipJugadorDerrota;
    [Header("\t\t\t---Enemigo---")]
    [SerializeField] private AudioClip clipEnemigoDerrota;

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
        }
    }

    public void JugadorSalto(Transform transformObject)
    {
        AudioSource tempAudioSource = Instantiate(prefabAudioSource, transformObject.position, Quaternion.identity);
        tempAudioSource.clip = clipJugadorSalto;
        tempAudioSource.Play();
        // agregamos el objeto a eliminar y el delay antes de que suceda
        Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
    }

    public void JugadorHerido(Transform transformObject)
    {
        AudioSource tempAudioSource = Instantiate(prefabAudioSource, transformObject.position, Quaternion.identity);
        tempAudioSource.clip = clipJugadorHerido;
        tempAudioSource.Play();
        Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
    }
    public void JugadorAtaque(Transform transformObject)
    {
        AudioSource tempAudioSource = Instantiate(prefabAudioSource, transformObject.position, Quaternion.identity);
        tempAudioSource.clip = clipJugadorAtaque;
        tempAudioSource.Play();
        Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
    }

    public void JugadorDerrota(Transform transformObject)
    {
        AudioSource tempAudioSource = Instantiate(prefabAudioSource, transformObject.position, Quaternion.identity);
        tempAudioSource.clip = clipJugadorDerrota;
        tempAudioSource.Play();
        Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
    }
    public void EnemigoDerrota(Transform transformObject)
    {
        AudioSource tempAudioSource = Instantiate(prefabAudioSource, transformObject.position, Quaternion.identity);
        tempAudioSource.clip = clipEnemigoDerrota;
        tempAudioSource.Play();
        Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
    }

}
