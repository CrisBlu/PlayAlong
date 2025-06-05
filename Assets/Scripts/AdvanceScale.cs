using UnityEngine;

public class AdvanceScale : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private bool forward;
    [SerializeField] Tutorial tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if(forward)
        {
            tutorial.NextScale(1);
        }
        else
        {
            tutorial.NextScale(-1);
        }
    }
}
