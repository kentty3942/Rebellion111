using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*//攻撃の属性クラス（変数は適当）
public class AttackType
{
    public string name;
    public sprite icon;
}

//攻撃属性クラスを継承した各属性作る
public class AttackSlash : AttackType
{  //斬撃
}
public class AttackFire : AttackType
{  //炎
}

//ダメージを受けるオブジェクトの基底クラス
//インターフェースではなく抽象クラスにする（MonoBehaviour入れるならここ）
public class DamageManager : MonoBehaviour
{ 
    public void Damage(float power, AttackSlash type)
{
    //斬撃ダメージ時のデフォ処理
}
public void Damage(float power, AttackFire type)
{
    //炎ダメージ時のデフォ処理
}
public void Damage(float power, AttackType type)
{
    //それ以外のダメージ時のデフォ処理
}

    //武器クラス
    public class Weapon : MonoBehaviour
    {
        public float weaponpower;
        public AttackType[] types;    //インスペクタから入れるなり装備時に入れるなりしておく

        //攻撃中だけ武器のColliderが有効になる
        void OnTriggerEnter2D(Collider2D Hitcollider)
        {
            //当たったオブジェクトがIDamageableを継承したオブジェクトなら    
            if (Hitcollider.GetComponent<Damageable>() != null)
            {
                foreach (var item in types)
                {
                    Hitcollider.GetComponent<Damageable>().Damage(weaponpower, item);
                }
            }
        }
    }
    //敵クラス
    public class Enemy : Damageable
    {
        public void Damage(float power, AttackSlash type)
        {
            //斬撃ダメージ時の処理（デフォ処理と違う処理をしたい場合）
        }

        //デフォ通りの処理をするならそのメソッドの実装の必要は無い
    }

    //木箱クラス
    public class Kibako : Damageable
    {
        public void Damage(float power, AttackSlash type)
        {
            //斬撃ダメージ時の処理（デフォ処理と違う処理をしたい場合）
        }

        //デフォ通りの処理をするならそのメソッドの実装の必要は無い
    }
}*/