using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    PlayerController m_playerController;
    //移動速度
    public float m_speed = 20f;
    //視野
    public float m_angle = 90f;
    float m_accel = 0;
    float m_steering = 0;
    float m_SpeedScale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_playerController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        {
            //transform.forwardは自分が向いている方向を表すベクトル
            pos += transform.forward * m_speed * m_accel * m_SpeedScale * Time.deltaTime;
        }
        transform.position = pos;
        //旋回処理-----------------------------------------------------
        //現在の回転情報を取得
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += m_angle * m_steering * Time.deltaTime * 1.2f;
        //変更した値を反映
        transform.rotation = Quaternion.Euler(rot);
        //変更したフラグを元に戻す
        m_accel = 0;
        m_steering = 0;

    }
    //前後
    public void Accel(float vertical/*horizontal*/)
    {
        m_accel = vertical/*horizontal*/;
    }
    //左右
    public void Steering(float horizontal/*value*/)
    {
        m_steering = horizontal/*value*/;
    }
}

