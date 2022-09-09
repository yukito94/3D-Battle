using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    //�X���C�_�[�ōU���̌����鉻��}��
    public Slider HPGauge;

    //���j�b�g�����������Ă��邩��錾����
    int hp; //���݂�hp
    int maxHp = 1000;  //�ő��hp(�{��͓G��������1000�Ƃ���)

    public int attack; //�U����

    //�����悻�̎��Ԑݒ�i��莞�ԂōU���������j
    private float attackTime;


    // Start is called before the first frame update
    void Start()
    {
    hp = maxHp; //�����l�͂��̂܂�

    HPGauge.maxValue = maxHp;
    HPGauge.value = maxHp;
    
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
        attackTime -= Time.deltaTime;
        if (attackTime <= 0.0) {
        attackTime = 3.0f;
    
        //�U���͂͂��̓s�x�ύX����K�v������ׁA�����ɋL�ځi���b�P��U�����鎖�ƂȂ��Ă��邪Update�̓t���[���œ����Ă邽�߁A�ǂ����肳��Ă邩�v�����j
        attack = Random.Range(1, 99);    //�U����

        //�i�O�q�ƌ�q�̊T�O��ǉ�����ꍇ�͂����ɋL�ڂ���j
    }
    
    }
}
