using UnityEngine;
using System.Collections;

public class TriggerMover : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
    }
}
