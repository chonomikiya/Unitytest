using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarCtl : MonoBehaviour
{
    Slider _slider;
    Slider _bossSlider;
    float _hp = 40;
    float _bossHP = 100;
    GameObject player = null;
    [SerializeField]
    GameObject bossObject = null;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _hp = _slider.value;
        player = GameObject.Find("Player");
        _bossHP = bossObject.GetComponent<bossWeapongenerater>().bossHP;
        _bossSlider = GameObject.Find("BossSlider").GetComponent<Slider>();
    }

    public void HPpull(int damage){
        _hp -= damage;
        if(_hp < 0){
            _hp = 0;
            player.GetComponent<PlayerController>().fall();
        }
        _slider.value = _hp;
    }
    public void BossHPbarappear(){
        _bossSlider.value = _bossHP;
    }
    public void BossHPPull(){
        _bossHP--;
        if(_bossHP < 0){
            _bossHP = 0;
        }
        _bossSlider.value = _bossHP;
    }
}
