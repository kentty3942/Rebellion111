using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public Transform[] point;
    private int m_destPoint = 0;
    private NavMeshAgent agent;
    
  
    enum ActionType
    {
        Attack,         //攻撃
        Escape,         //回避
        Guard,          //ガード
        Provocation,    //挑発
        TekeABreak,     //間合いを取る
        GetClose,       //近づく
        Patrol          //巡回
    }
    ActionType m_actionType = ActionType.GetClose;      //現在の行動パターン
    ActionType m_lastActionType = ActionType.GetClose;  //ひとつ前に行った行動パターン

    UnityEngine.AI.NavMeshAgent m_navMeshAgent;

    Movecontrore m_moveContoroller;
    [SerializeField]
    GameObject m_traget; //目標
    Movecontrore m_targetMoveController; //目標が持っているムーブcontroller
    [SerializeField]
    private SimpleAnimation m_simpleAnimation;

    



    // Start is called before the first frame update
    void Start()
    {

        m_moveContoroller = GetComponent<Movecontrore>();
        m_navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //目標のムーブcontrollerを取得
        m_targetMoveController = m_traget.GetComponent<Movecontrore>();
        //巡回初期値
        agent = GetComponent<NavMeshAgent>();
        //速度を落とさない
      
        GotoNextPoint();

        ChangeActionType(ActionType.Patrol);

    }

    // Update is called once per frame
    void Update()
    {


        switch (m_actionType)
        {
            case ActionType.Attack:
                Attack();
                break;
            case ActionType.Escape:
                Escape();
                break;
            case ActionType.Guard:
                Guard();
                break;
            case ActionType.Provocation:
                Provocation();
                break;
            case ActionType.TekeABreak:
                TekeABreak();
                break;
            case ActionType.GetClose:
                GetClose();
                break;
            case ActionType.Patrol:
                Patrol();
                break;
        }
    }


    void Attack()
    {

    }
    void Escape()
    {

    }
    void Guard()
    {

    }
    void Provocation()
    {
        ChangeActionType(ActionType.Provocation);
    }
    void TekeABreak()
    {

    }
    void Patrol() {
        //エージェントが目標地点に近づいてきたら、次の目標地点を選択する。
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
    public void FoundPlayer()
    {
        ChangeActionType(ActionType.GetClose);
    }
    public void LostPlayer()
    {
        ChangeActionType(ActionType.Patrol);
    }
    void GetClose()
    {
        
        
        //NavMeshの経路探索の準備ができているなら
        if (m_navMeshAgent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
           

            //自動でPlayerに近づく
            m_navMeshAgent.SetDestination(m_traget.transform.position);
            
        }
      /*  //近づいているときに攻撃されたら　避ける、ガードする、そのまま突っ込む
        if (m_targetMoveController.IsAttacking())
        {
            int rnd = Random.Range(0, 100);
            if (rnd < 30)
            {
                //避ける
            }
            else if (rnd < 60)
            {
                //ガード
            }
        }*/

        //近づいている最中に挑発
        else if (Random.Range(0, 60) < 1)
        {
            //ステートを変える
            ChangeActionType(ActionType.Provocation);
        }
        //近づいたら攻撃
        else if (Vector3.Distance(transform.position, m_traget.transform.position) < 1f)
        {
            //ステートを変える
            ChangeActionType(ActionType.Attack);
        }
    }



    /// <summary>
    /// actionタイプを変えるためのメソッド
    /// </summary>
    /// <param name="type"></param>
    void ChangeActionType(ActionType type)
    {
        m_lastActionType = m_actionType;     //ひとつ前の行動を更新
        m_actionType = type;                 //新しい行動をセット
        switch (m_actionType)
        {
            case ActionType.Attack:
                m_moveContoroller.Attack();
                break;
            case ActionType.Escape:
                break;
            case ActionType.Guard:
                break;
            case ActionType.Provocation:
                Debug.Log("povocation");
                break;
            case ActionType.TekeABreak:
                break;
            case ActionType.GetClose:
                agent.autoBraking = true;
                break;
            case ActionType.Patrol:
                agent.autoBraking = false;
                break;
        }
    }
    void GotoNextPoint()
    {
        //地点に何も設定されていないときに返す
        if(point.Length == 0)
        {
            return;
        }
        //エージェントが現在設定された目標地点に行くように設定する
        agent.destination = point[m_destPoint].position;
        //配列内の次の位置を目標地点に設定し、必要なら出発点にもどる
        m_destPoint = (m_destPoint + 1) % point.Length;
    }
}
