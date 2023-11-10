using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _object; // ������� ������� ������ � �������
    [SerializeField] float RandX; // ������������ �� � �������
    [SerializeField] Vector3 _whereToSpawn; // ��� ��������(���� � ��� �� ������� ��� ��� �����)
    [SerializeField] public float spawnRate = 1f;
    [SerializeField] float nextSpawn = 0.0f;
    public SpawnBoss SB;
    public GameObject _boss;
    private void Update()
    {


        if (Time.time > nextSpawn && SB.StarTime < 10f)
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(12f, -12f);
                _whereToSpawn = new Vector3(RandX, 3.29f);
                Quaternion _rotate = new Quaternion(0, -180, 0, 0);
                Instantiate(_object[Random.Range(0, _object.Length)], _whereToSpawn, _rotate);
            }
        
        
    }
}
