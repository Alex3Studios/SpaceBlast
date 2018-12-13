using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Vector3 centerPos;
    public Transform cameraT;
    public static float shakeDuration;
    public float shakeForce = 0.15f;

    void Start()
    {
        centerPos = cameraT.localPosition;
    }
    void Awake()
    {
        if (cameraT == null)
            cameraT = GetComponent(typeof(Transform)) as Transform;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            cameraT.localPosition = centerPos + Random.insideUnitSphere * shakeForce;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cameraT.localPosition = centerPos;
        }
    }
}