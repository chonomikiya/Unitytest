using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneDirector : MonoBehaviour
{
    [SerializeField]
    GameObject player = null;
    public void LoadGameOver(){
        SceneManager.LoadScene("GameOverScene");
    }
    public void LoadGameClear(){
        SceneManager.LoadScene("ClearScene");
    }
    public void BossDefeat(){
        Camera.main.GetComponent<CameraController>().isClear();
        // player.GetComponent<PlayerController>().isGameClear();
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
