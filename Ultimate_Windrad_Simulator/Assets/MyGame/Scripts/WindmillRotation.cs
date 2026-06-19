using System;
using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] Transform bladeT;

    private Renderer[] bladeRenderers;

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
            bladeT.Rotate(Vector3.up * rotationSpeed);
        }

        // Ändert die Farbe nun kontinuierlich in jedem Frame basierend auf der aktuellen Geschwindigkeit
        ApplyColorBasedOnSpeed();
    }

    void ApplyColorBasedOnSpeed()
    {
        if (bladeRenderers == null || bladeRenderers.Length == 0) return;

        Color targetColor = Color.green;

        // Nutzt die Grenzwerte (0-30, 31-70, 71-100) direkt aus deiner Aufgabenstellung
        if (rotationSpeed >= 0f && rotationSpeed <= 30f)
        {
            targetColor = Color.green;
        }
        else if (rotationSpeed >= 31f && rotationSpeed <= 70f)
        {
            targetColor = Color.yellow;
        }
        else if (rotationSpeed >= 71f)
        {
            targetColor = Color.red;
        }

        foreach (Renderer rend in bladeRenderers)
        {
            if (rend != null && rend.material != null)
            {
                rend.material.color = targetColor;
            }
        }
    }
}