using System.Collections;
using UnityEngine;

public class HallwayGuard : MonoBehaviour
{
    [SerializeField] GameObject GameOverIndicator;
    [SerializeField] float speed = 2f;
    [SerializeField] float distance = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Patrol());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverIndicator.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    IEnumerator Patrol()
    {
        float covered = 0f;
        while (covered < distance)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            covered += speed * Time.deltaTime;
            yield return null;
        }
        transform.Rotate(0, 180, 0);
        StartCoroutine(Patrol());
    }
}
