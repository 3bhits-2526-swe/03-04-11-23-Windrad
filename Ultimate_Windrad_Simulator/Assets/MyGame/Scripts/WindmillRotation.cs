using System;
using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] Transform bladeT;

    void Start()
    {
        // apply random position offset for more natural looks
        bladeT.Rotate(Vector3.up * UnityEngine.Random.Range(1f, 1.5f));
    }

    void Update()
    {
        bladeT.Rotate(Vector3.up * rotationSpeed);
    }
}
