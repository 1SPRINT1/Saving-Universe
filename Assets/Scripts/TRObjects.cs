using UnityEngine;
public class TRObjects : MonoBehaviour
{
    public float _speed;
    public GameObject _Trash;
    public GameObject hitEffector5;
    private void Update()
    {
        transform.Translate(new Vector3(0,0,- _speed * Time.deltaTime));
    }
    private void FixedUpdate()
    {
        if (transform.position.z < -45f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_Trash)
        {
            if (collision.gameObject.CompareTag("Fire"))
            {
                Destroy(gameObject);
                GameObject effect5 = Instantiate(hitEffector5, transform.position, Quaternion.identity);
                Destroy(effect5, 3f);
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (_Trash)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }

}
