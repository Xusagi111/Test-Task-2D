using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayerState : MonoBehaviour
{
    private const string a = "CountPlayer";
    private int CounCheck;
    [SerializeField] private Text CountStatePlayer;
    private void Start()
    {
        CountStatePlayer.text = SaveCountState().ToString();
    }
   public static int SaveCountState(int CounCheck = 0)
   {
        CounCheck += PlayerPrefs.GetInt(a);
        PlayerPrefs.SetInt(a, CounCheck);
        return CounCheck;
   }
}
