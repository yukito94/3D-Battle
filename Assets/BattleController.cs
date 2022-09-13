using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    //�X���C�_�[�ōU���̌����鉻��}��
    public Slider HPGauge;

    //���j�b�g�����������Ă��邩��錾����
    public int hp; //���݂�hp
    public int maxHp = 1000;  //�ő��hp(�{��͓G��������1000�Ƃ���)

    public int attack; //�U����

    //�����悻�̎��Ԑݒ�i��莞�ԂōU���������j
    private float attackTime;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp; //�����l�͂��̂܂�

        HPGauge.maxValue = maxHp;
        HPGauge.value = maxHp;

        //�J�n�u�ԂɃ_���[�W��0�ɂȂ�̂�h���ׂɋL�q(��)
        attack = Random.Range(11, 99); //(���L�q)
    }


    //�_���[�W�̌����鉻
    public void onDamage(int _damage){
        hp -= _damage;

        //�X���C�_�[�̐ݒ�
        //HP��0�ȉ��ɂȂ�����
        if(hp <= 0){
            hp = 0;
        }
        HPGauge.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        //�Đ��[���̐��\�E���ɕ΂炸��莞�Ԃ�ݒ�iTime.deltaTime�j
        //�U��������4�b�Ŋ�������悤�ɂ������B���ׁ̈A�����̍X�V���Ԃ�1.9�b�Ƃ���(2�b���ƍU�������������l�ɂȂ�ׂɏ������߂ɂ���B�v�΍�H)
        attackTime -= Time.deltaTime;
        if (attackTime <= 0.0) {
            attackTime = 1.9f;
    
            //�U���͂͂��̓s�x�ύX����K�v������ׁA�����ɋL��
            attack = Random.Range(11, 99);    //�U����

            //�O�q�ƌ�q�̊T�O��ǉ�����ꍇ�͂����ɋL�ڂ���
        }
    }
}
