using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class VivodScore : MonoBehaviour
{
    private PPlayerController PCont;
    public Text _VivodScora;

    public void Vivodik()
    {
        _VivodScora.text = YandexGame.savesData.monik.ToString();
    }

}
