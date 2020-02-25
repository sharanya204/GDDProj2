using UnityEngine;
public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string toScene;
    SceneController loadNextScene;

    void Start()
    {
        Debug.Log(toScene);
        //sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        loadNextScene = FindObjectOfType<SceneController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hit portal");
            loadNextScene.LoadNextScene();
        }
    }
}