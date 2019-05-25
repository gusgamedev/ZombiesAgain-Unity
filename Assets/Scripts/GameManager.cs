using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

   // public CameraShake shake;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);      

        DontDestroyOnLoad(gameObject);
    }
    
    public void ChangeScene(string nameScene)
    {
        if (nameScene == "MainMenu")
            SoundManager.instance.PlayMusic(SoundManager.instance.menuMusic);
        else if (nameScene == "Game")
            SoundManager.instance.PlayMusic(SoundManager.instance.gameMusic);
        else if (nameScene == "GameOver")
            SoundManager.instance.PlayMusic(SoundManager.instance.gameOverFx, false);

        SceneManager.LoadScene(nameScene); 

    }

    


}
