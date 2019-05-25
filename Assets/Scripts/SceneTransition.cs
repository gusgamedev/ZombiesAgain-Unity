using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneTransition : MonoBehaviour {

    private Animator transitionAnim;

    private void Start()
    {
        transitionAnim = GetComponent<Animator>();
       // SoundManager.instance.PlayMusic(SoundManager.instance.menuMusic);
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName) {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);

        GameManager.instance.ChangeScene(sceneName);
        

    }

}
