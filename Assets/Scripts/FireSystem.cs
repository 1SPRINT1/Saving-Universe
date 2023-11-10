using UnityEngine;
public class FireSystem : MonoBehaviour
{
    public float _StarTime;
    public float _EndTime;
    public Transform _firePos;
    public GameObject _fireobj;

    public float bulletForce = 20f;

    private void Update()
    {
           Shoot();
    }
    private void FixedUpdate()
    {
        _StarTime += 0.5f * Time.deltaTime;
    }
   public void Shoot()
    {

        if (_StarTime >= _EndTime)
        {
            GameObject bullshit = Instantiate(_fireobj, _firePos.position, _firePos.rotation);
            Rigidbody rg = bullshit.GetComponent<Rigidbody>();
            rg.AddForce(_firePos.up * bulletForce, ForceMode.Impulse);
        }
        if (_StarTime >= _EndTime)
        {
            _StarTime = 0f;
        }
        
    }
}
