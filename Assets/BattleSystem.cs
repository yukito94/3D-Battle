using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オートバトルが進行できるようここに記述を進めてく

public class BattleSystem : MonoBehaviour
{
    //おおよその時間設定（一定時間で攻撃しあう）
    private float xtime;

    //取得する情報
    //publicを追加することで他のデーター(この場合BattleController)から呼び込める
    public BattleController player;
    public BattleController enemy;

    //攻撃反撃
    bool PlayerTurn;

    // Start is called before the first frame update
    void Start()
    {

        //開始時はplayerが先行に設定
        PlayerTurn = true;

        //Invoke("Update", 3f); 不要になったら削除
        StartCoroutine("BattleStart");
    }


    IEnumerator BattleStart()
    {
        while(true){
            yield return new WaitForSeconds(2.0f);

                //ここからバトル周りの処理
                //playerがenemyを攻撃する
                enemy.onDamage(player.attack);
                PlayerTurn = false;

                Debug.Log("Enemyダメージ" + player.attack);

            yield return new WaitForSeconds(2.0f);

                //エネミーの攻撃に秒数は関係ない為、秒数のif文の外に記載する(その為にif!を使用して判断)
                if(!PlayerTurn){

                    PlayerTurn = true;
                    player.onDamage(enemy.attack);
                    Debug.Log("Playerダメージ" + enemy.attack);
                } 
        }
    }


    /*☆★下記、秒数で切り替えてた時のコード。コールチンが安定し、問題なければ削除する事★☆
    // Update is called once per frame
    void Update()
    {

        //再生端末の性能・環境に偏らず一定時間で攻撃できる（Time.deltaTime）
        xtime -= Time.deltaTime;
        if (xtime <= 0.0) {
            xtime = 4.0f;

            //ここからバトル周りの処理
            //playerがenemyを攻撃する
            enemy.onDamage(player.attack);
            PlayerTurn = false;

            Debug.Log("Enemyダメージ" + player.attack);

            //2秒後にPlayerTurnSを呼び出す。こうすると4秒で攻撃反撃が完結する
            Invoke("PlayerTurnS", 2.0f);
        }
    }

 
    void PlayerTurnS()
    {
        //エネミーの攻撃に秒数は関係ない為、秒数のif文の外に記載する(その為にif!を使用して判断)
        if(!PlayerTurn){

            PlayerTurn = true;
            player.onDamage(enemy.attack);
            Debug.Log("Playerダメージ" + enemy.attack);
        } 
    }
    */
}
