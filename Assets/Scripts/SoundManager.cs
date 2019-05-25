
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip gameOverFx;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

       // PlayMusic(menuMusic);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayMusic(AudioClip music, bool loopMusic = true)
    {
        audioSource.loop = loopMusic;

        audioSource.clip = music;
        audioSource.Play();
    }
}
