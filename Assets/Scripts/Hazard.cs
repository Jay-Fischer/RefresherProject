using UnityEngine;
using UnityEngine.Events;

public class Hazard : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnterHazard;
    [SerializeField] UnityEvent OnExitHazard;

    private void OnTriggerEnter(Collider other)
    {
        OnEnterHazard?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExitHazard?.Invoke();
    }
}
