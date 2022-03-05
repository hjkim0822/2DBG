using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    #region Declaration
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public Transform firePosition;

    public float fireRate = 2f;
    bool canShoot = true;
    #endregion Declaration

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")){
            Shoot();
        }
    }

    private void Shoot()
    {
        if (canShoot) { 
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletForce * firePosition.up, ForceMode2D.Impulse);

            StopCoroutine(IEFireRate());
            StartCoroutine(IEFireRate());
        }
    }

    IEnumerator IEFireRate() {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;

    }


}
