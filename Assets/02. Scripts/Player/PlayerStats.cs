using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    #region Declaration
    //hp variables
    float playerHP;
    public float maxHP = 2;

    public Slider sliderHP;
    public Gradient gradient;
    public Image fill;

    //speed variables
    float playerSpeed;
    public float startPlayerSpeed = 5;

    //size variables;
    Vector3 playerSize;
    public Vector3 startPlayerSize = new Vector3(1.0f, 1.0f, 1.0f);
    #endregion Declaration

    #region Player HP Property
    public float PLAYERHP
    {
        get { return playerHP; }
        set
        {
            playerHP = value;

            sliderHP.value = playerHP;
            fill.color = gradient.Evaluate(sliderHP.normalizedValue);
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
            //transform.localScale = playerSize;
           // transform.localScale = value;
        }
    }
    #endregion Player Size Property

    void Start()
    {
        PLAYERHP = maxHP;
        sliderHP.value = maxHP;
        fill.color = gradient.Evaluate(1f);

        PLAYERSPEED = startPlayerSpeed;
        transform.localScale = startPlayerSize;
        //PLAYERSIZE = startPlayerSize;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            if (PLAYERHP > 0) {
                PLAYERHP -= DamageManager.instance.damage;                      //damage
                transform.localScale += (DamageManager.instance.damage) * Vector3.one;     //size change
                print(transform.localScale);
                print(PLAYERHP);
            }
            if (PLAYERHP <= 0) {
                Destroy(this.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Fire"))
        {
            if (PLAYERHP > 0){
                PLAYERHP -= DamageManager.instance.firedamage;
                transform.localScale += (DamageManager.instance.firedamage) * Vector3.one;     //size change
                print(PLAYERHP);
                print(transform.localScale);

            }
            if (PLAYERHP <= 0){
                Destroy(this.gameObject);
            }
        }
    }
}
