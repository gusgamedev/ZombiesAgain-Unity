using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance; 

    public WaveSpawner waveSpawner;
    public DonutSpawner donutSpawner;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    public void StartGame()
    {
        waveSpawner.StartWave();
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
