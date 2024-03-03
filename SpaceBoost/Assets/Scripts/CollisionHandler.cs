using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        switch(collision.gameObject.tag) {
            case "Friend":
                Debug.Log("This thing is a friendly");
                break;
            case "Fuel":
                Debug.Log("You got fuel");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
