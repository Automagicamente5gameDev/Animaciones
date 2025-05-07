using UnityEngine;

public class SoundFXController : MonoBehaviour
{
    public static SoundFXController Instance { get; private set; } = null;
    [SerializeField] private AudioSource prefabAudioSource;
    private AudioSource caminarAudioSource;
    [Header("\t\t\t---Jugador---")]
    [SerializeField] private AudioClip clipJugadorSalto;
    [SerializeField] private AudioClip clipJugadorHerido;
    [SerializeField] private AudioClip clipJugadorAtaque;
    [SerializeField] private AudioClip clipJugadorDerrota;
    [SerializeField] private AudioClip clipJugadorCaminar;
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

    private void ReproducirSonido(Transform transformObject, AudioClip clip)
    {
        AudioSource tempAudioSource = Instantiate(prefabAudioSource, transformObject.position, Quaternion.identity);
        tempAudioSource.clip = clip;
        tempAudioSource.Play();
        // agregamos el objeto a eliminar y el delay antes de que suceda
        Destroy(tempAudioSource.gameObject, tempAudioSource.clip.length);
    }
   
    public void JugadorSalto(Transform transformObject) => ReproducirSonido(transformObject, clipJugadorSalto);
    public void JugadorHerido(Transform transformObject) => ReproducirSonido(transformObject, clipJugadorHerido);
    public void JugadorAtaque(Transform transformObject) => ReproducirSonido(transformObject, clipJugadorAtaque);
    public void JugadorDerrota(Transform transformObject) => ReproducirSonido(transformObject, clipJugadorDerrota);
    public void EnemigoDerrota(Transform transformObject) => ReproducirSonido(transformObject, clipEnemigoDerrota);

    public void JugadorCaminar(Transform transformObject)
    {
        if (caminarAudioSource == null)
        {
            caminarAudioSource = Instantiate(prefabAudioSource, transformObject.position, Quaternion.identity);
            caminarAudioSource.clip = clipJugadorCaminar;
            caminarAudioSource.loop = true;
            caminarAudioSource.pitch += 0.5f;//aumentar velocidad de sonido
            caminarAudioSource.Play();
        }
    }

    public void JugadorCaminar()
    {
        if (caminarAudioSource != null)
        {
            Destroy(caminarAudioSource.gameObject);
        }
    }
}
