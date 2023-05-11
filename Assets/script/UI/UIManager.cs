using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField]private GameObject gameOverScreen;

    [Header ("Pause")]
    [SerializeField] private GameObject pauseScreen;
    private void Start(){
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }
#region Game Over
    public void GameOver(){
        gameOverScreen.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
    #endif
    }
#endregion 

    public void PauseGame(bool status){
        pauseScreen.SetActive(status);

        if(status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
