using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    int hitpoint; // 현재 체력

    public int HITPOINT
    {
        get { return hitpoint; }

        set 
        {
            hitpoint = value;
        }
    }

    int starthp; //시작 체력 및 최대 체력

    public int STARTHP
    {
        get { return starthp; }

        set
        {
            starthp = value;
        }
    } //공통 변수

    public virtual void TakeDamage(int damage) //데미지 받는 메소드
    {
        hitpoint -= damage;
    }

}
