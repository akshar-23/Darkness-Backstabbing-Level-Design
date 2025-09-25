using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    [SerializeField] GameObject GameText;
    [SerializeField] TriggerZombie triggerZombie;
    void OnTriggerEnter(Collider other)
    {
        if (triggerZombie.trigg)
        {
            if (other.CompareTag("Player"))
            {
                GameText.GetComponentInChildren<TextMeshProUGUI>().text = "I managed to escape!";
                Time.timeScale = 0f;
            }
        }  
    }
}
