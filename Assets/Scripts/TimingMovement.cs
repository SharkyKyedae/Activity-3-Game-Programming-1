using UnityEngine;

public class TimingMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}