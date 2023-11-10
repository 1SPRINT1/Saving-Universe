using UnityEngine.UI;
using UnityEngine;
using YG;
using System.Collections;
using System;

public class ADManager : MonoBehaviour
{
    [Header("Доступ к Скриптам")]
    public InfoYG inYG;
    public PPlayerController Player;

    [Header("Панельки для вывода в конце")]
    public GameObject panelADisYes;
    public GameObject panelADisNo;

    [Header("Типо таймер")]
    public float StartADtimer;

    [Header("Для вывода времени таймера")]
    public Text TextTimer;

    private void Update()
    {
        if (!YandexGame.nowFullAd && !YandexGame.nowVideoAd && YandexGame.timerShowAd >= inYG.fullscreenAdInterval && Player.panelMenu.activeSelf == true)
        {
            panelADisYes.SetActive(true);
            panelADisNo.SetActive(false);
            StartCoroutine(ExecuteAfterTime(3));
            //StartADtimer += 1 * Time.deltaTime;
            //TextTimer.text = StartADtimer.ToString("00");
            //  if (StartADtimer >= 3)
            //  {
            //     YandexGame.FullscreenShow();
            //     panelADisYes.SetActive(false);
            //  }
            //  if (StartADtimer >= 10)
            //   {
            //      StartADtimer = 0;
            //   }
            if (StartADtimer == 3)
            {
                StopAllCoroutines();
            }
        }
        else if (Player.Lives < 1 && Player.panelMenu.activeSelf == true)
        {
            panelADisNo.SetActive(true);
        }
    }

    IEnumerator ExecuteAfterTime(int timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        if (timeInSec == 3)
        {
            YandexGame.FullscreenShow();
            panelADisYes.SetActive(false);
        }
    }
}
