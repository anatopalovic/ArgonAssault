using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float value = 10f;
    [SerializeField] float xRange = 5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;

    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] GameObject[] lasers;


    float yThrow;
    float xThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslations();
        ProcessRotation();
        ProcessFiring();
    }


    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }

    void ActivateLasers()
    {
        for (int i = 0; i < lasers.Length; i++)
        {
            var emmModule = lasers[i].GetComponent<ParticleSystem>().emission;
            emmModule.enabled = true;
            
        }
    }

    void DeactivateLasers()
    {
        for (int i = 0; i < lasers.Length; i++)
        {
            var emmModule = lasers[i].GetComponent<ParticleSystem>().emission;
            emmModule.enabled = false;
        }
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor
        + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = controlRollFactor * xThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslations()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * value;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, +xRange);



        float yOffset = yThrow * Time.deltaTime * value;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -2.5f, +4f);

        transform.localPosition = new Vector3(clampedXPos,
         clampedYPos, transform.localPosition.z);
    }
}
