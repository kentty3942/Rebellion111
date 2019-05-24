using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Axis : MonoBehaviour {

    //X軸の角度を制限するための変数
    float angleUp = 20f;
    float angleDown = -20f;

    //ユニティちゃんをInspectorで入れる
    [SerializeField] GameObject player;
    //Main CameraをInspectorで入れる
    [SerializeField] Camera cam;

    //Cameraが回転するスピード
    [SerializeField] float rotate_speed = 3;
    //Axisの位置を指定する変数
    [SerializeField] Vector3 axisPos;

    //マウススクロールの値を入れる
    [SerializeField] float scroll;
    //マウスホイールの値を保存
    [SerializeField] float scrollLog;

    public Comonn.JoyStickConfig m_AngleKey;//前後後退
    public Comonn.JoyStickConfig m_AnglesKey;

    string[] m_joyStickConfig = new string[(int)Comonn.JoyStickConfig.Num];

    void Start()
    {
        m_joyStickConfig[0] = Comonn.joystickHorizontal;
        m_joyStickConfig[1] = Comonn.joystickVertical;
        m_joyStickConfig[2] = Comonn.joystick1LeftHorizontal;
        m_joyStickConfig[3] = Comonn.joystick1LeftVertical;
        m_joyStickConfig[4] = Comonn.joystick1rightVertical;
        m_joyStickConfig[5] = Comonn.joystick1rightHorizontal;

        name = this.transform.name;

        //CameraのAxisに相対的な位置をlocalPositionで指定
        cam.transform.localPosition = new Vector3(0, 0, -3);
        //CameraとAxisの向きを最初だけそろえる
        cam.transform.localRotation = transform.rotation;
    }
    
    void Update()
    {
        //水平方向の入力を受け取る
        float horizontal = Input.GetAxis(m_joyStickConfig[(int)m_AngleKey]);

        //垂直方向の入力を受け取る
        float vertical = Input.GetAxis(m_joyStickConfig[(int)m_AnglesKey]);

        //Axisの位置をユニティちゃんの位置＋axisPosで決める
        transform.position = player.transform.position + axisPos;
        //三人称の時のCameraの位置にマウススクロールの値を足して位置を調整
        //thirdPosAdd = thirdPos + new Vector3(0, 0, scrollLog);

        //マウススクロールの値を入れる
        scroll = Input.GetAxis("Mouse ScrollWheel");
        //scrollAdd += Input.GetAxis("Mouse ScrollWheel") * -10;
        //マウススクロールの値は動かさないと0になるのでここで保存する
        scrollLog += Input.GetAxis("Mouse ScrollWheel");

        //Cameraの位置、Z軸にスクロール分を加える
        cam.transform.localPosition
            = new Vector3(cam.transform.localPosition.x,
            cam.transform.localPosition.y,
            cam.transform.localPosition.z + scroll);
        //Cameraの角度にマウスからとった値を入れる
        transform.eulerAngles += new Vector3(
            Input.GetAxis(Comonn.joystick1rightVertical) * rotate_speed,
            Input.GetAxis(Comonn.joystick1rightHorizontal) * rotate_speed
            , 0);
        /*//Cameraの角度にマウスからとった値を入れる
        transform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y") * rotate_speed,
            Input.GetAxis("Mouse X") * rotate_speed
            , 0);*/

        //X軸の角度
        float angleX = transform.eulerAngles.x;
        //X軸の値を180度超えたら360引くことで制限しやすくする
        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }
        //Mathf.Clamp(値、最小値、最大値）でX軸の値を制限する
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, angleDown, angleUp),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}