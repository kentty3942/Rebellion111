using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : MonoBehaviour
{
    [SerializeField]
    EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Search");
        if (col.gameObject.tag == "Player")
        {
            enemyController.FoundPlayer();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemyController.LostPlayer();
        }
    }
}
