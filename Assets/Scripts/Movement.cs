using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] private float thrustStrength = 1000f;
    [SerializeField] private float rotationStrength = 100f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainengineFX;
    [SerializeField] ParticleSystem leftengingeFX;
    [SerializeField] ParticleSystem rightengineFX;

    Rigidbody rb;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcccessThrust();
        ProccessRotation();
    }

    private void ProcccessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }

        else
        {
            audioSource.Stop();
            mainengineFX.Stop();
        }

    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX);
        }
        if (!mainengineFX.isPlaying)
        {
            mainengineFX.Play();
        }
    }

    private void ProccessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
            if (!leftengingeFX.isPlaying)
            {
                leftengingeFX.Play();
                rightengineFX.Stop();
            }
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
            if (!rightengineFX.isPlaying)
            {
                rightengineFX.Play();
                leftengingeFX.Stop();
            }
        }
        else
        {
            leftengingeFX.Stop();
            rightengineFX.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
