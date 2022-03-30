using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    [SerializeField] float violentShakeDuration = 2f;
    [SerializeField] float violentShakeMagnitude = 1.5f;

    [SerializeField] bool applyCameraShake;
    [SerializeField] bool applyViolentCameraShake;
    CameraShake cameraShake;

    Vector3 initialPosition;


    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }

    public void ViolentPlay()
    {
        StartCoroutine(ViolentShake());
    }

    IEnumerator ViolentShake()
    {
        float elapsedTime = 0;
        while (elapsedTime < violentShakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * violentShakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
