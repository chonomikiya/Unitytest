using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneDirector : MonoBehaviour
{
    public void LoadGameOver(){
        SceneManager.LoadScene("GameOverScene");
    }
    public void LoadGameClear(){
        SceneManager.LoadScene("ClearScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
