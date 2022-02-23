using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    #region Singleton 
    public static DamageManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion Singleton 

    public float speed;
    public float damage = 0.1f;
    public float firedamage = 0.2f;
    

}
