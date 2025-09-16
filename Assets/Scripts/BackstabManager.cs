using UnityEngine;
using UnityEngine.InputSystem;

public class BackstabManager : MonoBehaviour
{
    [SerializeField] GameObject backstabIndicator;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            backstabIndicator.SetActive(true);
            PlayerController.instance.backstabTarget = GetComponentInParent<Guard>();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            backstabIndicator.SetActive(false);
            PlayerController.instance.backstabTarget = null;
        }
    }
    public void HideIndicator()
    {
        backstabIndicator.SetActive(false);
    }
}
