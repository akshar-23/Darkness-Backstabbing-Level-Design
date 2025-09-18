using UnityEngine;
using UnityEngine.InputSystem;

public class BackstabManager : MonoBehaviour
{
    [SerializeField] GameObject backstabIndicator;
    [SerializeField] public bool hasFlashlight;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            backstabIndicator.SetActive(true);
            PlayerController.instance.backstabTarget = transform.parent.gameObject;
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
