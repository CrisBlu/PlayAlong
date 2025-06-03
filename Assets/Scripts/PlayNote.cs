using UnityEngine;
using TMPro;
public class PlayNote : MonoBehaviour
{
    private AudioSource audioSource;
    private TextMeshPro text;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        text = GetComponentInChildren<TextMeshPro>();
        text.text = gameObject.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        Debug.LogWarning("Playing");
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
        Debug.LogWarning("Stopping");
    }
}
