using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float BulletForce;
    public float timeBtwFire;

    void Start()
    {
        
    }

    void Update()
    {
        Rotate_gun();
        timeBtwFire -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    void Rotate_gun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        
        float angel =  Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angel);
        transform.rotation = rotation;
        
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1,-1,0);
        else
            transform.localScale = new Vector3(1, 1, 0);
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bullettmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        
        Rigidbody2D rb = bullettmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * BulletForce, ForceMode2D.Impulse);

        
    }
}
