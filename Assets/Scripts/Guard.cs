using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Guard : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float longDistance = 5f;
    [SerializeField] float shortDistance = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WalkLong());
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
}