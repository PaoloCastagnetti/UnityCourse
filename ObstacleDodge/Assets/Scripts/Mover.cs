using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField]
    float Speed;

    float xValue;
    float yValue;
    float zValue;

    void Update() {
        xValue = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        zValue = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        transform.Translate(xValue, yValue, zValue);
    }
}
