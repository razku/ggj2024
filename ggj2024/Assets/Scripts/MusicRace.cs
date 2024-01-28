using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float retrasoInicial = 3.4f;

    void Start()
    {
        // Inicia la reproducción después del retraso inicial
        Invoke("IniciarReproduccion", retrasoInicial);
    }

    void IniciarReproduccion()
    {
        // Reproduce la pista de audio
        audioSource.Play();
    }
}
