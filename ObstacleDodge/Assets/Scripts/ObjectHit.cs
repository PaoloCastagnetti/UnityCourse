using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField]
    Material hitMaterial;
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("ObjectHit: " + gameObject.name + " collided with " + collision.gameObject.name);

        if(collision.gameObject.tag == "Player") {
            GetComponent<MeshRenderer>().material = hitMaterial;
            gameObject.tag = "Hit";
        }
    }
}
