using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private float rotationAngleX;
    [SerializeField]
    private float rotationAngleY;
    [SerializeField]
    private float rotationAngleZ;

    private void Update() {
        transform.Rotate(rotationAngleX, rotationAngleY, rotationAngleZ);
    }
}
