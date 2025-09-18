using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] GameObject WinIndicator;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinIndicator.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
