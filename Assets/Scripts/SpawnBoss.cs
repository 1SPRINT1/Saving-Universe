using UnityEngine;
public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private GameObject[] _object; // Обьекты которые входят в спавнер
    [SerializeField] float RandX; // расположение по Х спавнер
    [SerializeField] Vector3 _whereToSpawn; // Где спавнить(пока я сам не выяснил что это такое)
    //[SerializeField] private float spawnRate = 2f; // раз в какое время спавнить
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
