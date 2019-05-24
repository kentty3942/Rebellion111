using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerActuon : MonoBehaviour
{
        /*public float power, time;
        public GameObject damageEffect;
        public Player pc;

        protected override void Start()
        {
            if (time != 0)
            {
                StartCoroutine(DestroyHit());
            }
        }

        protected virtual IEnumerator DestroyHit()
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
        //ダメージ処理
        /*protected virtual void OnTriggerEnter(Collider c)
        {
            if (TagUtility.getParentTagName(character.getGameObject().tag) == "Player")
            {
                if (TagUtility.getParentTagName(c.gameObject) == "Enemy")
                {
                    c.GetComponent<Enemy>().damage(power);
                    Instantiate(damageEffect, transform.position, Quaternion.identity);
                }
            }
        }*/
}
