using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Guard : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float longDistance = 5f;
    [SerializeField] float shortDistance = 2f;
    [SerializeField] Light flashlight;
    [SerializeField] GameObject GameOverIndicator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        StartCoroutine(WalkLong());
    }
    void Update()
    {
        if (IsPlayerInLight())
        {
            GameOverIndicator.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    IEnumerator WalkLong()
    {
        float covered = 0f;
        while (covered < longDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            covered += speed * Time.deltaTime;
            yield return null;
        }
        transform.Rotate(0, 90, 0);
        StartCoroutine(WalkShort());
    }
    IEnumerator WalkShort()
    {
        float covered = 0f;
        while (covered < shortDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            covered += speed * Time.deltaTime;
            yield return null;
        }
        transform.Rotate(0, 90, 0);
        StartCoroutine(WalkLong());
    }
    bool IsPlayerInLight()
    {
        Vector3 toPlayer = PlayerController.instance.transform.position - flashlight.transform.position;

        if (toPlayer.magnitude > flashlight.range)
            return false;

        float angleToPlayer = Vector3.Angle(flashlight.transform.forward, toPlayer.normalized);
        if (angleToPlayer > flashlight.spotAngle / 2f)
            return false;

        if (Physics.Raycast(flashlight.transform.position, toPlayer.normalized, out RaycastHit hit, flashlight.range))
        {
            if (hit.transform != PlayerController.instance.transform)
                return false; 
        }

        return true;
    }
}