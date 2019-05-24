using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecontrore : MonoBehaviour
{
    [SerializeField]
    float m_moveSpeed = 2f;
    [SerializeField]
    float m_rotateSpeed = 90f;
    Animator m_animator;
    const string kAttackParamName = "Attack";

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Move(float value)
    {
        transform.position += transform.forward * m_moveSpeed * value * Time.deltaTime;
    }

    public void Rotate(float value)
    {
        transform.Rotate(0, m_rotateSpeed * value * Time.deltaTime, 0f);
    }
    public void Attack()
    {

    }
    void ResetAttackParam()
    {
        m_animator.SetBool(kAttackParamName, false);
    }
    //攻撃中はtrueを返す関数
    public bool IsAttacking()
    {
        return m_animator.GetBool(kAttackParamName);
    }
}
