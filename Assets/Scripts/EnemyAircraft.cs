using UnityEngine;
public class EnemyAircraft : MonoBehaviour
{
    public float _speed = 2f; // �������� ����������� ����������
    public GameObject hitEffector4;
    private void Update()
    {
        // ������������ ����� 
        transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime)); 
    }
    public void OnCollisionEnter(Collision collision)
    {
        // ��������� ����� �����
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
        // ������� ������������ �����
        if (transform.position.z < -45f)
        {
            Destroy(gameObject);
        }
    }
}
