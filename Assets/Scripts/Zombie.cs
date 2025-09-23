using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;
    bool isChasing = false;
    [SerializeField] GameObject GameOverIndicator;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && isChasing)
        {
            agent.SetDestination(player.position);
        }
    }

    public void EnableChase()
    {
        isChasing = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverIndicator.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
