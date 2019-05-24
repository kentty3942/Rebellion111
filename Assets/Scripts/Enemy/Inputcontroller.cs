using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputcontroller : MonoBehaviour
{
    Movecontrore m_movecontrore;
    // Start is called before the first frame update
    void Start()
    {
        m_movecontrore = GetComponent<Movecontrore>();

    }

    // Update is called once per frame
    void Update()
    {
        //前後移動
        m_movecontrore.Move(Input.GetAxis("Vertical"));
        //左右回転
        m_movecontrore.Rotate(Input.GetAxis("Horizontal"));

    }
}
