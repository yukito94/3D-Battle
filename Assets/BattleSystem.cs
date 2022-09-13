using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オートバトルが進行できるようここに記述を進めてく

public class BattleSystem : MonoBehaviour
{
    //おおよその時間設定（一定時間で攻撃しあう）
    private float xtime;

    //攻撃反撃
    bool PlayerTurn;

    //取得する情報
    //publicを追加することで他のデーター(この場合BattleController)から呼び込める
    public BattleController player; //わかりやすくするために二つ使用
    public BattleController enemy;

    //ダメージカウント
    int playerHp;    //リアルタイムの値を設定
    int enemyHp;
    

    // Start is called before the first frame update
    void Start()
    {

        //開始時はplayerが先行に設定
        PlayerTurn = true;

        Invoke("Update", 2f); 

        //ダメージカウントの初期値を設定
        playerHp = player.maxHp;
        enemyHp = enemy.maxHp;
    }


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

                enemyHp -= player.attack;  //ダメージカウント
                Debug.Log("Enemyダメージ" + player.attack　+　"。HP残量" + enemyHp);


                //クリア処理
                if(enemyHp <= 0){
                
                    Debug.Log("クリア！！");
                }

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

            playerHp -= enemy.attack;  //ダメージカウント
            Debug.Log("Playerダメージ" + enemy.attack　+　"。HP残量" + playerHp);

            
            //ゲームオーバー処理
            if(playerHp <= 0){
            
                Debug.Log("Playerは倒れた");
            }

        } 
    }
}
