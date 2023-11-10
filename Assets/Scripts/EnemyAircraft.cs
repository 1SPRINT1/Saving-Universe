using UnityEngine;
public class EnemyAircraft : MonoBehaviour
{
    public float _speed = 2f; // Скорость перемещения Противника
    public GameObject hitEffector4;
    private void Update()
    {
        // передвижение врага 
        transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime)); 
    }
    public void OnCollisionEnter(Collision collision)
    {
        // получение урона врага
        if (collision.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject);
            GameObject effect4 = Instantiate(hitEffector4, transform.position, Quaternion.identity);
            Destroy(effect4, 3f);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject effect4 = Instantiate(hitEffector4, transform.position, Quaternion.identity);
            Destroy(effect4, 3f);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        // граница передвижения врага
        if (transform.position.z < -45f)
        {
            Destroy(gameObject);
        }
    }
}
