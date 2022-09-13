using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    //スライダーで攻撃の見える化を図る
    public Slider HPGauge;

    //ユニットが何を持っているかを宣言する
    public int hp; //現在のhp
    public int maxHp = 1000;  //最大のhp(本作は敵味方共に1000とする)

    public int attack; //攻撃力

    //おおよその時間設定（一定時間で攻撃しあう）
    private float attackTime;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp; //初期値はそのまま

        HPGauge.maxValue = maxHp;
        HPGauge.value = maxHp;

        //開始瞬間にダメージが0になるのを防ぐ為に記述(仮)
        attack = Random.Range(11, 99); //(仮記述)
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
        //攻撃反撃は4秒で完了するようにしたい。その為、乱数の更新時間を1.9秒とする(2秒だと攻撃反撃が同じ値になる為に少し早めにする。要対策？)
        attackTime -= Time.deltaTime;
        if (attackTime <= 0.0) {
            attackTime = 1.9f;
    
            //攻撃力はその都度変更する必要がある為、ここに記載
            attack = Random.Range(11, 99);    //攻撃力

            //前衛と後衛の概念を追加する場合はここに記載する
        }
    }
}
