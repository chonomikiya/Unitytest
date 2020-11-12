using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UIのkeyの処理、リファクタリング対象20201112

public class key_help : MonoBehaviour
{
    Color input_color = new Color (169/255.0f,169/255.0f,169/255.0f);
    Color colorwhite = new Color(1f,1f,1f,1f);
    [SerializeField]
    GameObject siftctl = null;
    [SerializeField]
    GameObject z_ctl = null;
    [SerializeField]
    GameObject x_ctl = null;
    [SerializeField]
    GameObject arrow_up = null;
    [SerializeField]
    GameObject arrow_down = null;
    [SerializeField]
    GameObject arrow_left = null;
    [SerializeField]
    GameObject arrow_right = null;
    Vector3 offset = new Vector3(0,1f,0);
    //それぞれの処理
    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            siftctl.GetComponent<Image>().color = input_color;
            siftctl.transform.position -= offset;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            siftctl.GetComponent<Image>().color = colorwhite;
            siftctl.transform.position += offset;
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            z_ctl.GetComponent<Image>().color = input_color;
            z_ctl.transform.position -= offset;
        }
        if(Input.GetKeyUp(KeyCode.Z)){
            z_ctl.GetComponent<Image>().color = colorwhite;
            z_ctl.transform.position += offset;
        }

        if(Input.GetKeyDown(KeyCode.X)){
            x_ctl.GetComponent<Image>().color = input_color;
            x_ctl.transform.position -= offset;
        }
        if(Input.GetKeyUp(KeyCode.X)){
            x_ctl.GetComponent<Image>().color = colorwhite;
            x_ctl.transform.position += offset;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            arrow_up.GetComponent<Image>().color = input_color;
            arrow_up.transform.position -= offset;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            arrow_up.GetComponent<Image>().color = colorwhite;
            arrow_up.transform.position += offset;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            arrow_down.GetComponent<Image>().color = input_color;
            arrow_down.transform.position -= offset;
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)){
            arrow_down.GetComponent<Image>().color = colorwhite;
            arrow_down.transform.position += offset;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            arrow_left.GetComponent<Image>().color = input_color;
            arrow_left.transform.position -= offset;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            arrow_left.GetComponent<Image>().color = colorwhite;
            arrow_left.transform.position += offset;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            arrow_right.GetComponent<Image>().color = input_color;
            arrow_right.transform.position -= offset;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
            arrow_right.GetComponent<Image>().color = colorwhite;
            arrow_right.transform.position += offset;
        }
    }
}