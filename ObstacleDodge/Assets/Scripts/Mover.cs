using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField]
    float Speed;

    float xValue;
    float yValue;
    float zValue;

    private void Start() {
        //PrintInstructions();
    }

    void Update() {
        MovePlayer();
    }

    void PrintInstructions() {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer() {
        xValue = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        zValue = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        transform.Translate(xValue, yValue, zValue);
    }
}
