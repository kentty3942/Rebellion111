using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllers : MonoBehaviour
{
    /*private GameObject player;       //プレイヤー格納用

    // Use this for initialization
    void Start()
    {
        //unitychanをplayerに格納
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //左方向が押されている時
        if (Input.GetKey(KeyCode.joystick1LeftHorizontal))
        {
            //中心に-5f度回転
            transform.RotateAround(player.transform.position, Vector3.up, -5f);
        }
        //右方向が押されている時
        else if (Input.GetKey(KeyCode.joystick1LeftVertical))
        {
            //中心に5f度回転
            transform.RotateAround(player.transform.position, Vector3.up, 5f);
        }
    }
}
    /*GameObject Player;
    GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {

        mainCamera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);

    }*/
}

   /* public GameObject m_target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //カメラの移動
        Vector3 pos = m_target.transform.position + (-m_target.transform.forward * 8f); //６ｍ後ろにカメラを移動
        pos.y += 2f;                        //高さを上げる
        pos = Vector3.Lerp(transform.position, pos, 0.1f);  //カメラの移動を遅らせる
        transform.position = pos;           //変更した値を反映

        //目標のほうを向く
        transform.LookAt(m_target.transform.position);

    }
}*/
