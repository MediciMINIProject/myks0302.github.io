using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    int hitpoint; // ���� ü��

    public int HITPOINT
    {
        get { return hitpoint; }

        set 
        {
            hitpoint = value;
        }
    }

    int starthp; //���� ü�� �� �ִ� ü��

    public int STARTHP
    {
        get { return starthp; }

        set
        {
            starthp = value;
        }
    } //���� ����

    public virtual void TakeDamage(int damage) //������ �޴� �޼ҵ�
    {
        hitpoint -= damage;
    }

}
