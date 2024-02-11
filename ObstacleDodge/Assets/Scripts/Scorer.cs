using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    private void OnCollisionEnter(Collision collision) {
        ++hits;
        Debug.Log("You collided this many times: " + hits);
    }
}
