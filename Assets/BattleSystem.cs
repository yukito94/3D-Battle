using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�I�[�g�o�g�����i�s�ł���悤�����ɋL�q��i�߂Ă�

public class BattleSystem : MonoBehaviour
{
    //�����悻�̎��Ԑݒ�i��莞�ԂōU���������j
    private float xtime;

    //�擾������
    //public��ǉ����邱�Ƃő��̃f�[�^�[(���̏ꍇBattleController)����Ăэ��߂�
    public BattleController player;
    public BattleController enemy;

    //�U������
    bool PlayerTurn;

    // Start is called before the first frame update
    void Start()
    {

        //�J�n����player����s�ɐݒ�
        PlayerTurn = true;

        //Invoke("Update", 3f); �s�v�ɂȂ�����폜
        StartCoroutine("BattleStart");
    }


    IEnumerator BattleStart()
    {
        while(true){
            yield return new WaitForSeconds(2.0f);

                //��������o�g������̏���
                //player��enemy���U������
                enemy.onDamage(player.attack);
                PlayerTurn = false;

                Debug.Log("Enemy�_���[�W" + player.attack);

            yield return new WaitForSeconds(2.0f);

                //�G�l�~�[�̍U���ɕb���͊֌W�Ȃ��ׁA�b����if���̊O�ɋL�ڂ���(���ׂ̈�if!���g�p���Ĕ��f)
                if(!PlayerTurn){

                    PlayerTurn = true;
                    player.onDamage(enemy.attack);
                    Debug.Log("Player�_���[�W" + enemy.attack);
                } 
        }
    }


    /*�������L�A�b���Ő؂�ւ��Ă����̃R�[�h�B�R�[���`�������肵�A���Ȃ���΍폜���鎖����
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

            Debug.Log("Enemy�_���[�W" + player.attack);

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
            Debug.Log("Player�_���[�W" + enemy.attack);
        } 
    }
    */
}
