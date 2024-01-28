using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    void Start()
    {
        // Agregar un listener al evento de clic del botón
        GetComponent<Button>().onClick.AddListener(ReproducirSonido);
    }

    void ReproducirSonido()
    {
        // Llamar al método EjecutarSonido del AudioManager
        AudioManager.Instance.EjecutarSonido(clip);
    }
}
