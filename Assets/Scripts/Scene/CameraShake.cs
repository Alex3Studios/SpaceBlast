using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Vector3 centerPos;
    public Transform camera;
    public static float shakeDuration;
    public float shakeForce = 0.15f;

    void Start()
    {
        centerPos = camera.localPosition;
    }
    void Awake()
    {
        if (camera == null)
            camera = GetComponent(typeof(Transform)) as Transform;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camera.localPosition = centerPos + Random.insideUnitSphere * shakeForce;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            camera.localPosition = centerPos;
        }
    }
}