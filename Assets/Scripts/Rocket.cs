using UnityEngine;
public class Rocket : MonoBehaviour
{
    public GameObject hitEffector;
    public float StartTime;
    public float EndTime;
    public int _rocketDamage = 10;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(hitEffector, transform.position,Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        StartTime += 0.5f * Time.deltaTime;
        if (StartTime >= EndTime)
        {
            Destroy(gameObject);
        }
    }
}
