using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Sceneの管理用20201112
public class GameSceneDirector : MonoBehaviour
{
    public void LoadGameOver(){
        SceneManager.LoadScene("GameOverScene");
    }
    public void LoadGameClear(){
        SceneManager.LoadScene("ClearScene");
    }
    public void BossDefeat(){
        Camera.main.GetComponent<CameraController>().isClear();
    }
}
