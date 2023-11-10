using UnityEngine;
using UnityEngine.UI;
using YG;
using System.Collections;
using System.Collections.Generic;


public class PPlayerController : MonoBehaviour
{
    [Header("Доступ к скриптам")]
    public YandexGame YGa;
    public InfoYG inYG;
    public FireSystem FirePlayer;
    
    [Header("Сбор и Урон")]
    [SerializeField] private float _damage;// Урон надо будет убрать с игрока
    [SerializeField] private Text _coin;// Денюшка
    [SerializeField] private Text _cointwoTXT;// деньга
    [SerializeField] private Text _BustCoinTXT;
    public GameObject hitEffector;
    public GameObject hitEffector2;
    public GameObject hitEffector3;
    private int StartBustCoin = 0;
    private int MaxBustCoin = 5;
    [Header("Скорость персонажа")]
    public float _speed = 6f;
    public float _accelerationSpeed = 2f;
    //Панелька
    [Header("Панельки")]
    public GameObject panelMenu;
    [SerializeField] private GameObject MobileMenu;
    //Жизни
    [Header("Система Жизней")]
    public int Lives = 3;
    private int maxLives = 3;
    public int numOfLives;
    public Image[] Live;
    public Sprite fullLive;
    public Sprite emptyLive;
    float laneOffset;// нужно будет убрать
    //персик
    [Header("Всякая какаха")]
    private Rigidbody _rg;
    public Transform _playerTransform;

    //Таймер для бустера все для бустера
    [Header("Бустер")]
    public float StartTime;
    public float EndTime;
    [Header("Джойстик")]
    public float horizontal;
    public Joystick joystick;

    private void OnEnable() 
    { 
        YandexGame.GetDataEvent += GetLoad;
    }
    private void OnDisable() 
    { 
        YandexGame.GetDataEvent -= GetLoad;
    }

    public void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    private void Start()
    {
        MAircraftCoint = YandexGame.savesData.MBmoney;
        _BustCoinTXT.text = YandexGame.savesData.MBmoney.ToString();

       if (YandexGame.EnvironmentData.isMobile == true)
        {
            PanelMobileMenuSwitch();
        }
        Time.timeScale = 1f;
        _rg = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        StartTime += 0.5f * Time.deltaTime;

        if (Lives > numOfLives)
        {
            Lives = numOfLives;
        }
        for (int i = 0; i < Live.Length; i++)
        {
            if(i < Mathf.RoundToInt(Lives))
            {
                Live[i].sprite = fullLive;
            }
            else
            {
                Live[i].sprite = emptyLive;
            }
            if (i < numOfLives)
            {
                Live[i].enabled = true;
            }
            else
            {
                Live[i].enabled = false;
            }  
        }
    }
    public Vector3 directionVector;
    private void Update()
    {
        if (YandexGame.EnvironmentData.isMobile == true)
        {
            horizontal = joystick.Horizontal;
            directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
            _rg.velocity = directionVector * _speed;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
           directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
            _rg.velocity = directionVector * _speed;
        }
      //  horizontal = joystick.Horizontal;   
       // directionVector = new Vector3(horizontal * _accelerationSpeed,0,0);
       // _rg.velocity = directionVector * _speed;
      //  horizontal = Input.GetAxis("Horizontal");

        HealthLowed();
        BustUping();

        if (YandexGame.savesData.monik > YandexGame.savesData.BestScore)
        {
            YandexGame.savesData.BestScore = YandexGame.savesData.monik;
            MySave();
        }
        Debug.Log($"До запроса к показу Fullscreen рекламы {(inYG.fullscreenAdInterval - YandexGame.timerShowAd).ToString("00.0")} сек.");
    }

    private void OnCollisionStay(Collision collision)
    {
      //  if (collision.gameObject.CompareTag("Barrier"))
       // {
        //    PanelMenuSwitch();
        //}
        if (collision.gameObject.CompareTag("Finish"))
        {
            PanelMenuSwitch();
        }
    }

    public int coins;
    public int MAircraftCoint = 0;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coins++;
            _coin.text = coins.ToString();
            _cointwoTXT.text = coins.ToString();
            if (coins > 0)
            {
                MySave();
            }
            GameObject effect3 = Instantiate(hitEffector3, transform.position, Quaternion.identity);
            Destroy(effect3, 3f);
            other.gameObject.SetActive(false);
            _coin.text = coins.ToString();
            _cointwoTXT.text = coins.ToString();
        }
        else if (other.gameObject.CompareTag("BAirMoney"))
        {
            
            MAircraftCoint++;
            GameObject effect3 = Instantiate(hitEffector3, transform.position, Quaternion.identity);
            Destroy(effect3, 3f);
            other.gameObject.SetActive(false);
            _BustCoinTXT.text = MAircraftCoint.ToString();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Lives--;
            GameObject effect2 = Instantiate(hitEffector2, transform.position, Quaternion.identity);
            Destroy(effect2, 3f);
        }
        if (collision.gameObject.CompareTag("Medicine"))
        {
            Lives += 1;
            if (Lives > maxLives)
            {
                Lives = maxLives;
            }
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Fire"))
        {
            Lives--;
            GameObject effect2 = Instantiate(hitEffector2, transform.position, Quaternion.identity);
            Destroy(effect2, 3f);
            if (MAircraftCoint != StartBustCoin)
            {
                MAircraftCoint--;
            }
            _BustCoinTXT.text = MAircraftCoint.ToString();   
        }
 
    }
    private void PanelMenuSwitch()
    {
        panelMenu.SetActive(!panelMenu.activeInHierarchy);
    }
    private void PanelMobileMenuSwitch()
    {
        MobileMenu.SetActive(!MobileMenu.activeInHierarchy);
    }
    public void BustUping()
    {
        if (MAircraftCoint == 1)
        {
            _accelerationSpeed = 2.5f;
            _speed = 6.5f;
        }
        if (MAircraftCoint == 2)
        {
            _accelerationSpeed = 3f;
            _speed = 7f;
        }
        if (MAircraftCoint == 3)
        {
            _accelerationSpeed = 4f;
            _speed = 7f;
            FirePlayer._EndTime = 0.25f;
        }
        if (MAircraftCoint == 4)
        {
            _accelerationSpeed = 5f;
            _speed = 8f;
            FirePlayer._EndTime = 0.2f;
        }
        if (MAircraftCoint == 5)
        {
            _accelerationSpeed = 6f;
            _speed = 9f;
            FirePlayer._EndTime = 0.15f;
        }
        if (MAircraftCoint == 5)
        {
            MAircraftCoint = MaxBustCoin;
            FirePlayer._EndTime = 0.1f;
        }
        if (MAircraftCoint == 0)
        {
            MAircraftCoint = StartBustCoin;
        }
    }
    public void HealthLowed()
    {
        if (Lives == 3)
        {
            _accelerationSpeed = 2f;
            _speed = 6.5f;
        }

        if (Lives == 2)
        {
            _accelerationSpeed = 1.7f;
            _speed = 6f;
        }

        if (Lives == 1)
        {
            _speed = 5f;
            _accelerationSpeed = 1.3f;
        }

        if (Lives < 1)
        {
            PanelMenuSwitch();
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameObject effect = Instantiate(hitEffector, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            Destroy(gameObject);
        }
    }

    private int _pustishka;
    private float _empty;
    public void GetLoad()
    {
       // _cointwoTXT.text = YandexGame.savesData.BestScore.ToString();
        _BustCoinTXT.text = YandexGame.savesData.MBmoney.ToString();
        _pustishka = YandexGame.savesData.monik;
        _empty = YandexGame.savesData.BestScore;
    }
    
    public void MySave()
    { 
        YandexGame.savesData.monik = coins;
        YandexGame.savesData.MBmoney = MAircraftCoint;
        YandexGame.SaveProgress();
    }
    
}
