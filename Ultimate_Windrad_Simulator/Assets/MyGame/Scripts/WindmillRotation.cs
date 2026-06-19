using System;
using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] Transform bladeT;
    [SerializeField] float colorLerpSpeed = 5f; // Geschwindigkeit des Übergangs

    private Renderer[] bladeRenderers;
    private Color currentColor = Color.green;

    void Awake()
    {
        if (bladeT != null)
        {
            bladeRenderers = bladeT.GetComponentsInChildren<Renderer>();
        }
    }

    void Start()
    {
        if (bladeT != null)
        {
            bladeT.Rotate(Vector3.up * UnityEngine.Random.Range(1f, 1.5f));
        }
    }

    void Update()
    {
        if (bladeT != null)
        {
            // Multipliziert mit Time.deltaTime für frameraten-unabhängige Rotation
            bladeT.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        ApplyColorBasedOnSpeed();
    }

    void ApplyColorBasedOnSpeed()
    {
        if (bladeRenderers == null || bladeRenderers.Length == 0) return;

        Color targetColor = Color.green;

        if (rotationSpeed >= 0f && rotationSpeed <= 30f)
        {
            targetColor = Color.green;
        }
        else if (rotationSpeed > 30f && rotationSpeed <= 70f)
        {
            targetColor = Color.yellow;
        }
        else if (rotationSpeed > 70f)
        {
            targetColor = Color.red;
        }

        // Smoother Übergang via Lerp
        currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * colorLerpSpeed);

        foreach (Renderer rend in bladeRenderers)
        {
            if (rend != null && rend.material != null)
            {
                rend.material.color = currentColor;
            }
        }
    }
}