using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Declaration
    //hp variables
    float playerHP;
    public float maxHP = 2;

    //speed variables
    float playerSpeed;
    public float startPlayerSpeed = 5;

    //size variables;
    Vector3 playerSize;
    public Vector3 startPlayerSize = new Vector3 (1.0f, 1.0f, 1.0f);
    #endregion Declaration

    #region Player HP Property
    public float PLAYERHP
    {
        get { return playerHP; }
        set
        {
            playerHP = value;
        }
    }
    #endregion Player HP Property

    #region Player Speed Property
    public float PLAYERSPEED
    {
        get { return playerSpeed; }
        set
        {
            playerSpeed = value;
        }
    }
    #endregion Player Speed Property

    #region Player Size Property
    public Vector3 PLAYERSIZE
    {
        get { return playerSize; }
        set
        {
            transform.localScale = value;
            //transform.localScale = playerSize;
        }
    }
    #endregion Player Size Property
    

    void Start()
    {
        PLAYERHP = maxHP;
        PLAYERSPEED = startPlayerSpeed;
        PLAYERSIZE = startPlayerSize;
    }
}
