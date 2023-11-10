using UnityEngine;
public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private GameObject[] _object; // ������� ������� ������ � �������
    [SerializeField] float RandX; // ������������ �� � �������
    [SerializeField] Vector3 _whereToSpawn; // ��� ��������(���� � ��� �� ������� ��� ��� �����)
    //[SerializeField] private float spawnRate = 2f; // ��� � ����� ����� ��������
    //[SerializeField] float nextSpawn = 0.0f;
    public float StarTime;
    public float EndTime;
    private void FixedUpdate()
    {
        StarTime += 0.5f * Time.deltaTime;
    }
    private void Update()
    {

        if (StarTime >= 10f)
        {
            RandX = -0.88f;
            _whereToSpawn = new Vector3(RandX, 3.23f);
            Quaternion union = new Quaternion(0,-180f,0f,0f);
            Instantiate(_object[Random.Range(0, _object.Length)], _whereToSpawn, union);
        }
        if (StarTime >= EndTime)
        {
            StarTime = 0f;
        }
    }
}
