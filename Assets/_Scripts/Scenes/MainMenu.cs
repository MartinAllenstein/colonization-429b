using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] 
    private string nextScene;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

