using UnityEngine;
using UnityEngine.Audio;

public class MenuSoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;


    public void SetSonidoGeneral(float nivel)
    {
        audioMixer.SetFloat("SonidoGeneral", nivel);
    }
    public void SetSonidoFondo(float nivel)
    {
        audioMixer.SetFloat("SonidoFondo", nivel);
    }
    public void SetSonidoFX(float nivel)
    {
        audioMixer.SetFloat("SonidoFX", nivel);
    }
}
