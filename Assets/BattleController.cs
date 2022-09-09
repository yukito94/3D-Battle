using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    //スライダーで攻撃の見える化を図る
    public Slider HPGauge;

    //ユニットが何を持っているかを宣言する
    int hp; //現在のhp
    int maxHp = 1000;  //最大のhp(本作は敵味方共に1000とする)

    public int attack; //攻撃力

    //おおよその時間設定（一定時間で攻撃しあう）
    private float attackTime;


    // Start is called before the first frame update
    void Start()
    {
    hp = maxHp; //初期値はそのまま

    HPGauge.maxValue = maxHp;
    HPGauge.value = maxHp;
    
    }


    //ダメージの見える化
    public void onDamage(int _damage){
        hp -= _damage;

        //スライダーの設定
        //HPが0以下になった時
        if(hp <= 0){
            hp = 0;
        }
        HPGauge.value = hp;

    }

    // Update is called once per frame
    void Update()
    {
        //再生端末の性能・環境に偏らず一定時間を設定（Time.deltaTime）
        attackTime -= Time.deltaTime;
        if (attackTime <= 0.0) {
        attackTime = 3.0f;
    
        //攻撃力はその都度変更する必要がある為、ここに記載（毎秒１回攻撃する事となっているがUpdateはフレームで動いてるため、どう判定されてるか要調査）
        attack = Random.Range(1, 99);    //攻撃力

        //（前衛と後衛の概念を追加する場合はここに記載する）
    }
    
    }
}
