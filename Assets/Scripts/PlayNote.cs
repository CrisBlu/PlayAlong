using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
public class PlayNote : MonoBehaviour
{
    private AudioSource audioSource;
    private TextMeshPro text;
    private MeshRenderer meshRenderer;
    private Material defaultMat;
    [SerializeField] Material outlineMat;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        text = GetComponentInChildren<TextMeshPro>();
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMat = meshRenderer.material;
        text.text = gameObject.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
    }

    public void Highlight()
    {
        meshRenderer.materials = new Material[] { defaultMat,  outlineMat};
    }

    public void UnHighlight()
    {
        meshRenderer.materials = new Material[] { defaultMat };
    }
}
