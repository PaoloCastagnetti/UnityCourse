using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    // PARAMETERS - for tuning, in editor
    [SerializeField] 
    private float levelLoadDelay = 1f;
    [SerializeField]
    private AudioClip successSFX;
    [SerializeField]
    private AudioClip crashSFX;

    // CACHE - references
    private Movement movementComponent;
    private AudioSource audioSource;

    private void Start() {
        movementComponent = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        switch(collision.gameObject.tag) {
            case "Friend":
                Debug.Log("This thing is a friendly");
                break;
            /*case "Fuel":
                Debug.Log("You got fuel");
                break;*/
            case "Finish":
                LoadNextLevel();
                break;
            default:
                CrashSequence();
                break;
        }
    }
    void SuccessSequence() {
        audioSource.Stop();
        movementComponent.enabled = false;
        audioSource.PlayOneShot(successSFX);
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void CrashSequence() {
        audioSource.Stop();
        movementComponent.enabled = false;
        audioSource.PlayOneShot(crashSFX);
        Invoke("ReloadLevel", levelLoadDelay);
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
