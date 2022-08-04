using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //NavAgent�� ����ϱ� ���� �غ�

public class Enemy : HP
{
    #region ���� ����
    public enum EnemyType { Close, Range, Suicide }; //���� ���� ����
    public static EnemyType enemyType;

    public enum EnemyRank { Normal, Cadre}; //���� ���
    public static EnemyRank enemyRank;
    #endregion

    #region ���� ����
    public float speed; //�� �̵� �ӵ�
    #endregion

    #region ���� AI
    public GameObject Target; //������ �� : �ٸ�����Ʈ

    public NavMeshAgent NavMeshAgent; //AI �̽� �غ�
    float distance; //�ڽŰ� Ÿ�ٰ��� �Ÿ�
    #endregion

    #region ���� ����
    bool isDead; //��� ���� ����
    #endregion

    #region ��ƼŬ �� �ִϸ��̼� ����
    public GameObject[] enemtprefabs; //ĳ���� ����(3����)

    public Animator[] animators; //�ִϸ��̼� ����
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;

        //���� ü�� ���� 
        switch (enemyType)
        {
            case EnemyType.Close:
                switch (enemyRank)
                {
                    case EnemyRank.Normal:
                        STARTHP = 125;
                        break;
                    
                    case EnemyRank.Cadre:
                        STARTHP = 200;
                        break;
                }

                break;
            case EnemyType.Range:
                switch (enemyRank)
                {
                    case EnemyRank.Normal:
                        STARTHP = 80;
                        break;

                    case EnemyRank.Cadre:
                        STARTHP = 140;
                        break;
                }
                break;
            
            case EnemyType.Suicide:
                switch (enemyRank)
                {
                    case EnemyRank.Normal:
                        STARTHP = 100;
                        break;

                    case EnemyRank.Cadre:
                        STARTHP = 150;
                        break;
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision) //���� ���μ���()
    {
        
    }

    void Dead()
    {
        if (HITPOINT < 0) //���� ü�� < 0
        {
            isDead = true; //������� Ȱ��ȭ

        }
        
        //��� �ִϸ��̼� �۵�

        //2���� ����
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
