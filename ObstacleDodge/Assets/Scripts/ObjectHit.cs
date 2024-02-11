using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("ObjectHit: " + gameObject.name + " collided with " + collision.gameObject.name);
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}
