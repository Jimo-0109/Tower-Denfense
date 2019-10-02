using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {   

    public SceneFaded sceneFaded;

    public string menuSceneName;

    
	public void Retry()
    {
        sceneFaded.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFaded.FadeTo(menuSceneName);
    }
}
