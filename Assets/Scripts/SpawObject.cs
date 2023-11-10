using UnityEngine;
public class SpawObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _object; // Обьекты которые входят в спавнер
    [SerializeField] float RandX; // расположение по Х спавнер
    [SerializeField] Vector3 _whereToSpawn; // Где спавнить(пока я сам не выяснил что это такое)
    [SerializeField] private float spawnRate = 2f; // раз в какое время спавнить
    [SerializeField] float nextSpawn = 0.0f;
    private void Update()
    {
        if (Time.time > nextSpawn)// && StarTime < 10f)
        {
            nextSpawn = Time.time + spawnRate;
            RandX = Random.Range(12f, -12f);
            _whereToSpawn = new Vector3(RandX, 3.29f);
            Instantiate(_object[Random.Range(0,_object.Length)], _whereToSpawn, Quaternion.identity);
        }
    }
}
