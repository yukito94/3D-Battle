using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�I�[�g�o�g�����i�s�ł���悤�����ɋL�q��i�߂Ă�

public class BattleSystem : MonoBehaviour
{
    //�����悻�̎��Ԑݒ�i��莞�ԂōU���������j
    private float xtime;

    //�U������
    bool PlayerTurn;

    //�擾������
    //public��ǉ����邱�Ƃő��̃f�[�^�[(���̏ꍇBattleController)����Ăэ��߂�
    public BattleController player; //�킩��₷�����邽�߂ɓ�g�p
    public BattleController enemy;

    //�_���[�W�J�E���g
    int playerHp;    //���A���^�C���̒l��ݒ�
    int enemyHp;
    

    // Start is called before the first frame update
    void Start()
    {

        //�J�n����player����s�ɐݒ�
        PlayerTurn = true;

        Invoke("Update", 2f); 

        //�_���[�W�J�E���g�̏����l��ݒ�
        playerHp = player.maxHp;
        enemyHp = enemy.maxHp;
    }


    // Update is called once per frame
    void Update()
    {


            //�Đ��[���̐��\�E���ɕ΂炸��莞�ԂōU���ł���iTime.deltaTime�j
            xtime -= Time.deltaTime;
            if (xtime <= 0.0) {
                xtime = 4.0f;

                //��������o�g������̏���
                //player��enemy���U������
                enemy.onDamage(player.attack);
                PlayerTurn = false;

                enemyHp -= player.attack;  //�_���[�W�J�E���g
                Debug.Log("Enemy�_���[�W" + player.attack�@+�@"�BHP�c��" + enemyHp);


                //�N���A����
                if(enemyHp <= 0){
                
                    Debug.Log("�N���A�I�I");
                }

                //2�b���PlayerTurnS���Ăяo���B���������4�b�ōU����������������
                Invoke("PlayerTurnS", 2.0f);
            }
    }



    void PlayerTurnS()
    {
        //�G�l�~�[�̍U���ɕb���͊֌W�Ȃ��ׁA�b����if���̊O�ɋL�ڂ���(���ׂ̈�if!���g�p���Ĕ��f)
        if(!PlayerTurn){

            PlayerTurn = true;
            player.onDamage(enemy.attack);

            playerHp -= enemy.attack;  //�_���[�W�J�E���g
            Debug.Log("Player�_���[�W" + enemy.attack�@+�@"�BHP�c��" + playerHp);

            
            //�Q�[���I�[�o�[����
            if(playerHp <= 0){
            
                Debug.Log("Player�͓|�ꂽ");
            }

        } 
    }
}
