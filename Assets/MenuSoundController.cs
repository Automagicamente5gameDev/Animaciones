using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [Header("\t\t\t----Sliders----")]
    [SerializeField] private Slider sliderSonidoGeneral;
    [SerializeField] private Slider sliderSonidoFondo;
    [SerializeField] private Slider sliderSonidoFX;

    private void Start()
    {
        float tempVolumen = 0f;
        audioMixer.GetFloat("SonidoGeneral", out tempVolumen);//obtengo el volumen actual desde audoMixer
        sliderSonidoGeneral.value = Mathf.Clamp(Mathf.Pow(10f, tempVolumen / 20f), 0.0001f, 1f);
        audioMixer.GetFloat("SonidoFondo", out tempVolumen);//obtengo el volumen actual desde audoMixer
        sliderSonidoFondo.value = Mathf.Clamp(Mathf.Pow(10f, tempVolumen / 20f), 0.0001f, 1f);
        audioMixer.GetFloat("SonidoFX", out tempVolumen);//obtengo el volumen actual desde audoMixer
        sliderSonidoFX.value = Mathf.Clamp(Mathf.Pow(10f, tempVolumen / 20f), 0.0001f, 1f);
    }

    public void RegresarMenu()
    {
        //sacamos la escena de menu sonido
        SceneManager.UnloadSceneAsync("MenuSonido");
        //activamos la escena de menu
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void SetSonidoGeneral(float nivel)
    {
        audioMixer.SetFloat("SonidoGeneral", Mathf.Log10(nivel)*20f);
    }
    public void SetSonidoFondo(float nivel)
    {
        audioMixer.SetFloat("SonidoFondo", Mathf.Log10(nivel) * 20f);
    }
    public void SetSonidoFX(float nivel)
    {
        audioMixer.SetFloat("SonidoFX", Mathf.Log10(nivel) * 20f);
    }
}
