/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    float deltaTime;
    float waitTime = 1.5f;  // 連続攻撃の受付開始時間（秒）
    float overTime = 2.5f;  // 連続攻撃の受付終了時間（秒）
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deltaTime = 0f;
    }

    // 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deltaTime += Time.deltaTime;

        if (deltaTime > waitTime && animator.GetBool("ComboChance") == false)  // 連続攻撃の受付開始
        {
            animator.SetBool("ComboChance", true);
        }

        if (deltaTime > overTime && animator.GetBool("ComboChance") == true)   // 連続攻撃の受付終了
        {
            animator.SetBool("ComboChance", false);
        }
    }

    // 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("ComboChance", false);                                // 連続攻撃の受付終了
    }
}*/