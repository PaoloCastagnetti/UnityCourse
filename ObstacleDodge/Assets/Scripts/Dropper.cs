using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField]
    private float timeToWait;

    private MeshRenderer meshRenderer;
    private Rigidbody rigidbody;

    private void Start() {
        //Getting the MeshRenderer component from the GameObject
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

        //Getting the Rigidbody component from the GameObject
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private void Update() {
        if (Time.time > timeToWait) {
            Debug.Log(timeToWait + " sec passed");

            meshRenderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
