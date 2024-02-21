using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    float mainThrust = 100f;

    [SerializeField]
    float rotationThrust = 100f;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    //Process the thrusting of the rocket
    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        }
    }

    //Process the rotation of the rocket
    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
