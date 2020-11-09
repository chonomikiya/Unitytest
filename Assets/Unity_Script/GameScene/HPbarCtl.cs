using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarCtl : MonoBehaviour
{
    Slider _slider;
    float _hp = 40;
    GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _hp = _slider.value;
        player = GameObject.Find("Player");
    }
    // // Update is called once per frame
    // void Update()
    // {
    //     // _hp += 0.01f;
    //     // if(_hp > 20) {
    //     // // 最大を超えたら0に戻す
    //     // _hp = 0;
    //     // }
    //     _slider.value = _hp;
    // }
    public void HPpull(int damage){
        _hp -= damage;
        if(_hp < 0){
            _hp = 0;
            player.GetComponent<PlayerController>().fall();
        }
        _slider.value = _hp;
    }
}
