using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    #region Declaration
    int hp;
    public int maxHP = 2;
    #endregion Declaration

    #region HP Property
    public int HP
    {
        get { return hp; }
        set {
            hp = value;
        }
    }
    #endregion HP Property

    void Start()
    {
        HP = maxHP;
    }
}
