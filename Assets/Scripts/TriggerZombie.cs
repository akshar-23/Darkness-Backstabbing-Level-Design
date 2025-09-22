using UnityEngine;

public class TriggerZombie : MonoBehaviour
{
    [SerializeField] Zombie zombie;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zombie.EnableChase();
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }
}
