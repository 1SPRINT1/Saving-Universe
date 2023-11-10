using UnityEngine;
public class BossAirCraft : MonoBehaviour
{
    private float _speed = 4f; // Скорость перемещения Противника
    public int _health = 9;
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
            _health--;
            if (_health < 1)
            {
                Destroy(gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        if (transform.position.z < -13f)
        {
            _speed = 0.1f;
        }
        // граница передвижения врага где он пропадает
        if (transform.position.z < -45f)
        {
            Destroy(gameObject);
        }
    }
}
