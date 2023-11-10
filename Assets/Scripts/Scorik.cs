using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class Scorik : MonoBehaviour
{
    public Text _viv;
    private void Update()
    {
        _viv.text = YandexGame.savesData.BestScore.ToString();
    }
}
