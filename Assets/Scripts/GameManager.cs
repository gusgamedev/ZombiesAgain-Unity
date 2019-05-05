using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CameraShake shake;
    public WaveSpawner waveSpawner;
    public DonutSpawner donutSpawner;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }

  
    // Update is called once per frame
    public void StartGame()
    {
        waveSpawner.StartWave();
    }

    


}
