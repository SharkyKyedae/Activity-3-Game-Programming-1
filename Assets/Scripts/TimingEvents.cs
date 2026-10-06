using UnityEngine;
using System.Collections;

public class TimingEvents : MonoBehaviour
{
    public GameObject disappearingObject;
    public GameObject spawnPrefab;

    void Start()
    {
        // Disappear after 5 seconds
        if (disappearingObject != null)
            Invoke(nameof(DisappearObject), 5f);

        // Spawn every 3 seconds
        if (spawnPrefab != null)
            InvokeRepeating(nameof(SpawnObject), 2f, 3f);

        // Speed boost
        StartCoroutine(SpeedBoost());
    }

    void DisappearObject()
    {
        if (disappearingObject != null)
            disappearingObject.SetActive(false);
    }

    void SpawnObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-6f, 6f),
            0.5f,
            Random.Range(-4f, 4f)
        );

        Instantiate(spawnPrefab, randomPosition, Quaternion.identity);
    }

    IEnumerator SpeedBoost()
    {
        yield return new WaitForSeconds(2f);

        TimingMovement movement = GetComponent<TimingMovement>();

        if (movement != null)
        {
            float normalSpeed = movement.speed;

            movement.speed *= 2f;

            yield return new WaitForSeconds(5f);

            movement.speed = normalSpeed;
        }
    }
}