using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Comonn.JoyStickConfig m_accelKey;//前後後退
    public Comonn.JoyStickConfig m_steeringKey;

    Animation anim;
    public KeyCode m_AttackKey = KeyCode.A;
    public KeyCode m_Attack2Key = KeyCode.S;
    string[] m_joyStickConfig = new string[(int)Comonn.JoyStickConfig.Num];
    public PlayerMovementController m_playermovementController;

    private string name;

    [SerializeField]
    private SimpleAnimation _simpleAnimation;

    Vector3 m_transform;
    //public float PredatTime;
    //public float pradatgauge = 0.0f;
    public bool isToilet = false;
    // Start is called before the first frame update
    void Start()
    {
        m_joyStickConfig[0] = Comonn.joystickHorizontal;
        m_joyStickConfig[1] = Comonn.joystickVertical;
        m_joyStickConfig[2] = Comonn.joystick1LeftHorizontal;
        m_joyStickConfig[3] = Comonn.joystick1LeftVertical;
        m_joyStickConfig[4] = Comonn.joystick1rightVertical;
        m_joyStickConfig[5] = Comonn.joystick1rightHorizontal;

        _simpleAnimation.CrossFade("Default", 0.5f);

        name = this.transform.name;

        //m_simpleAnimation = GetComponent<SimpleAnimation>();
        //SimpleAnimation.State state = m_simpleAnimation.GetState("Walk");
        //state.speed = 3;
        //PredatTime = 0;
        Debug.Log(name);
    }
    // Update is called once per frame
    void Update()
    {
        m_transform = this.gameObject.transform.position;

        if (m_transform.y < 0)
        {
            m_transform.y = 1.0f;
        }

        //水平方向の入力を受け取る
        float horizontal = Input.GetAxis(m_joyStickConfig[(int)m_steeringKey]);

        //垂直方向の入力を受け取る
        float vertical = Input.GetAxis(m_joyStickConfig[(int)m_accelKey]);

        if (isToilet == false /*&& m_timeLimitScript.isFinished == false*/)
        {
            if (vertical != 0)
            {
                m_playermovementController.Accel(vertical);
            
                /*if (PredatTime <= 0.0f)
                {
                    //m_simpleAnimation.CrossFade("Walk", 0.2f);
                }*/
            }

            if (horizontal != 0)
            {
                m_playermovementController.Steering(horizontal);
                /*if (PredatTime <= 0.0f)
                {
                   //m_simpleAnimation.CrossFade("Walk", 0.2f);
                }*/
            }

            /*if (vertical == 0 && horizontal == 0)
            {
                /*if (PredatTime <= 0.0f)
                {
                   //m_simpleAnimation.CrossFade("Default", 0.2f);
                }
            }*/
            //if (Input.GetKeyDown(m_AttackKey))
            //攻撃処理　Aボタンで攻撃＆□ボタン
            if (Input.GetButtonDown("Attack"))
            {
                Debug.Log("攻撃ボタンが押されました");
                _simpleAnimation.Play("Jab");
                //m_effectManager.Skill(this.gameObject);

                _simpleAnimation.CrossFade("Default", 0.5f);
                
                /*if (Input.GetButtonDown("ComboChance") == true)
                {
                   _simpleAnimation.Play/*SetTrigger
                ("ComboAttack");        // 連続攻撃*/
               
                //時間内にもう一度押されたら連続攻撃
            }
            
        }
        /*else if (Input.GetButtonDown("Attack2"))
        {
            Debug.Log("攻撃ボタン2が押されました");
            _simpleAnimation.Play("Hikick");
            //m_effectManager.Skill(this.gameObject);
            _simpleAnimation.CrossFade("Default", 0.5f);
        }*/
    }
}
