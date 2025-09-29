using UnityEngine;

public class WindowVault : MonoBehaviour
{
    [SerializeField] Collider collider1;
    [SerializeField] Collider collider2;
    [SerializeField] GameObject windowVaultPrompt;

    // Update is called once per frame
    void Update()
    {
        bool playerInCollider1 = false;
        bool playerInCollider2 = false;

        Collider[] hits1 = Physics.OverlapBox(collider1.bounds.center, collider1.bounds.extents, Quaternion.identity);
        foreach (var hit in hits1)
        {
            if (hit.CompareTag("Player"))
            {
                playerInCollider1 = true;
                break;
            }
        }

        Collider[] hits2 = Physics.OverlapBox(collider2.bounds.center, collider2.bounds.extents, Quaternion.identity);
        foreach (var hit in hits2)
        {
            if (hit.CompareTag("Player"))
            {
                playerInCollider2 = true;
                break;
            }
        }

        if (playerInCollider1)
        {
            PlayerController.instance.positionToVaultTo = collider2;
            windowVaultPrompt.SetActive(true);
        }
        else if (playerInCollider2)
        {
            windowVaultPrompt.SetActive(true);
            PlayerController.instance.positionToVaultTo = collider1;
        }
        else
        {
            windowVaultPrompt.SetActive(false);
            PlayerController.instance.positionToVaultTo = null;
        }
    }
}
