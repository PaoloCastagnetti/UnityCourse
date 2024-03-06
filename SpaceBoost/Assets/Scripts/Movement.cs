using UnityEngine;

public class Movement : MonoBehaviour {

    // PARAMETERS - for tuning, in editor
    [SerializeField]
    float mainThrust = 100f;

    [SerializeField]
    float rotationThrust = 100f;

    [SerializeField]
    AudioClip mainEngine;

    [SerializeField]
    ParticleSystem MainBooster;
    [SerializeField]
    ParticleSystem LeftBooster;
    [SerializeField]
    ParticleSystem RightBooster;

    // CACHE - references
    Rigidbody rb;
    AudioSource audioSource;

    // STATE - private instance 

    // METHODS
    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    //Process the thrusting of the rocket
    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {

            // Adding force to the rocket
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);

            // Playing SFX
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!MainBooster.isPlaying) {
                MainBooster.Play();
            }
        }
        else {
            audioSource.Stop();
            MainBooster.Stop();
        }
    }

    //Process the rotation of the rocket
    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            ApplyRotation(rotationThrust);
            if (!RightBooster.isPlaying) {
                RightBooster.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotationThrust);
            if (!LeftBooster.isPlaying) {
                LeftBooster.Play();
            }
        }
        else {
            RightBooster.Stop();
            LeftBooster.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
