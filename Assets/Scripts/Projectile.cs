using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damageAmount;
    public GameObject explosion;
    void Start()
    {
        Invoke("DestroyProjectile",lifeTime);
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {  
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamge(damageAmount);
            DestroyProjectile();
        }
    }
}
