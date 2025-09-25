using UnityEngine;
using TMPro;

public class TriggerZombie : MonoBehaviour
{
    [SerializeField] Zombie zombie;
    [SerializeField] GameObject GameText;
    public bool trigg = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameText.GetComponentInChildren<TextMeshProUGUI>().text = "She turned into a zombie! I have to escape!";
            zombie.EnableChase();
            trigg = true;
            Destroy(gameObject);
        }
    }
}
