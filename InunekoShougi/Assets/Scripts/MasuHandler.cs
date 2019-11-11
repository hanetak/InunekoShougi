using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuHandler : MonoBehaviour
{
    DirectionDeterminator directionDeterminator;
    komaIdou komaIdou;
    KomaModel komaModel;
    public int masuNum;
    public int nowMasuNum;
    public int komaShu;
    public bool komaNaru;
    public int komanarifield;
    float xzahyou;
    float yzahyou;
    int pID;
    int turn;

    void start()
    {
        komaIdou = GameObject.Find("KomaIdou").GetComponent<komaIdou>();
        komaModel = GetComponent<KomaModel>();
    }
    public void MasuCordinator(float x, float y, int cardIndex, bool Naru, int field, int mouse)
    {
        pID = PlayerPrefs.GetInt("pID");
        turn = PlayerPrefs.GetInt("turn");
        if (pID == 0)
        {
            pID = 1;
        }

        nowMasuNum = PlayerPrefs.GetInt("masu");
        if (-2.0f > x && x > -3.0f)
        {
            if (2.0f < y && y < 3.0f)
            {
                masuNum = 1;
                xzahyou = -2.5f;
                yzahyou =  2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                Debug.Log(masuNum);
            }
            else if (1.0f < y && y < 2.0f)
            {
                xzahyou = -2.5f;
                yzahyou = 1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 7;
                Debug.Log(masuNum);
            }
            else if (0.0f < y && y < 1.0f)
            {
                xzahyou = -2.5f;
                yzahyou = 0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 13;
                Debug.Log(masuNum);
            }
            else if (-1.0f < y && y < 0.0f)
            {
                xzahyou = -2.5f;
                yzahyou = -0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 19;
                Debug.Log(masuNum);
            }
            else if (-2.0f < y && y < -1.0f)
            {
                xzahyou = -2.5f;
                yzahyou =-1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 25;
                Debug.Log(masuNum);
            }
            else if (-3.0f < y && y < -1.0f)
            {
                xzahyou = -2.5f;
                yzahyou = -2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 31;
                Debug.Log(masuNum);
            }
            else
            {
            
                masuNum = 37;
            }
        }
        else if (-1.0f > x && x > -2.0f)
        {
            if (2.0f < y && y < 3.0f)
            {
                xzahyou = -1.5f;
                yzahyou = 2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 2;
                Debug.Log(masuNum);
            }
            else if (1.0f < y && y < 2.0f)
            {
                xzahyou = -1.5f;
                yzahyou = 1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 8;
                Debug.Log(masuNum);
            }
            else if (0.0f < y && y < 1.0f)
            {
                xzahyou = -1.5f;
                yzahyou = 0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 14;
                Debug.Log(masuNum);
            }
            else if (-1.0f < y && y < 0.0f)
            {
                xzahyou = -1.5f;
                yzahyou =-0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 20;
                Debug.Log(masuNum);
            }
            else if (-2.0f < y && y < -1.0f)
            {
                xzahyou = -1.5f;
                yzahyou = -1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 26;
                Debug.Log(masuNum);
            }
            else if (-3.0f < y && y < -1.0f)
            {
                xzahyou = -1.5f;
                yzahyou = -2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 32;
                Debug.Log(masuNum);
            }
            else
            {

                masuNum = 37;
            }
        }
        else if (0.0f > x && x > -1.0f)
        {
            if (2.0f < y && y < 3.0f)
            {
                xzahyou = -0.5f;
                yzahyou = 2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 3;
                Debug.Log(masuNum);
            }
            else if (1.0f < y && y < 2.0f)
            {
                xzahyou = -0.5f;
                yzahyou = 1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 9;
                Debug.Log(masuNum);
            }
            else if (0.0f < y && y < 1.0f)
            {
                xzahyou = -0.5f;
                yzahyou = 0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 15;
                Debug.Log(masuNum);
            }
            else if (-1.0f < y && y < 0.0f)
            {
                xzahyou = -0.5f;
                yzahyou = -0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 21;
                Debug.Log(masuNum);
            }
            else if (-2.0f < y && y < -1.0f)
            {
                xzahyou = -0.5f;
                yzahyou = -1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 27;
                Debug.Log(masuNum);
            }
            else if (-3.0f < y && y < -1.0f)
            {
                xzahyou = -0.5f;
                yzahyou = -2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 33;
                Debug.Log(masuNum);
            }
            else
            {

                masuNum = 37;
            }
        }
        else if (1.0f > x && x > 0.0f)
        {
            if (2.0f < y && y < 3.0f)
            {
                xzahyou = 0.5f;
                yzahyou = 2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 4;
                Debug.Log(masuNum);
            }
            else if (1.0f < y && y < 2.0f)
            {
                xzahyou = 0.5f;
                yzahyou = 1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 10;
                Debug.Log(masuNum);
            }
            else if (0.0f < y && y < 1.0f)
            {
                xzahyou = 0.5f;
                yzahyou = 0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 16;
                Debug.Log(masuNum);
            }
            else if (-1.0f < y && y < 0.0f)
            {
                xzahyou = 0.5f;
                yzahyou = -0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 22;
                Debug.Log(masuNum);
            }
            else if (-2.0f < y && y < -1.0f)
            {
                xzahyou = 0.5f;
                yzahyou = -1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 28;
                Debug.Log(masuNum);
            }
            else if (-3.0f < y && y < -1.0f)
            {
                xzahyou = 0.5f;
                yzahyou = -2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 34;
                Debug.Log(masuNum);
            }
            else
            {

                masuNum = 37;
            }
        }
        else if (2.0f > x && x > 1.0f)
        {
            if (2.0f < y && y < 3.0f)
            {
                xzahyou = 1.5f;
                yzahyou = 2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 5;
                Debug.Log(masuNum);
            }
            else if (1.0f < y && y < 2.0f)
            {
                xzahyou = 1.5f;
                yzahyou = 1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 11;
                Debug.Log(masuNum);
            }
            else if (0.0f < y && y < 1.0f)
            {
                xzahyou = 1.5f;
                yzahyou = 0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 17;
                Debug.Log(masuNum);
            }
            else if (-1.0f < y && y < 0.0f)
            {
                xzahyou = 1.5f;
                yzahyou = -0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 23;
                Debug.Log(masuNum);
            }
            else if (-2.0f < y && y < -1.0f)
            {
                xzahyou = 1.5f;
                yzahyou = -1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 29;
                Debug.Log(masuNum);
            }
            else if (-3.0f < y && y < -1.0f)
            {
                xzahyou = 1.5f;
                yzahyou = -2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 35;
                Debug.Log(masuNum);
            }
            else
            {

                masuNum = 37;
            }
        }
        else if (3.0f > x && x > 2.0f)
        {
            if (2.0f < y && y < 3.0f)
            {
                xzahyou = 2.5f;
                yzahyou = 2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 6;
                Debug.Log(masuNum);
            }
            else if (1.0f < y && y < 2.0f)
            {
                xzahyou = 2.5f;
                yzahyou = 1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 12;
                Debug.Log(masuNum);
            }
            else if (0.0f < y && y < 1.0f)
            {
                xzahyou = 2.5f;
                yzahyou = 0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 18;
                Debug.Log(masuNum);
            }
            else if (-1.0f < y && y < 0.0f)
            {
                xzahyou = 2.5f;
                yzahyou = -0.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 24;
                Debug.Log(masuNum);
            }
            else if (-2.0f < y && y < -1.0f)
            {
                xzahyou = 2.5f;
                yzahyou = -1.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum =30;
                Debug.Log(masuNum);
            }
            else if (-3.0f < y && y < -1.0f)
            {
                xzahyou = 2.5f;
                yzahyou = -2.5f;
                PlayerPrefs.SetFloat("x", xzahyou);
                PlayerPrefs.SetFloat("y", yzahyou);
                masuNum = 36;
                Debug.Log(masuNum);
            }
            else
            {

                masuNum = 37;
            }
        }
        else
        {
            masuNum = 37;
        }
        komaShu = cardIndex;
        komaNaru = Naru;
        komanarifield = field;

        //directionDeterminator.DirectionDetermine(komaNaru, komaShu, komanarifield);
        if(mouse == 1)
        {
            PlayerPrefs.SetInt("masu", masuNum);
            if (pID == 1)
            {
                //komaIdou.checkMasu(komaNaru, komaShu, pID);
            }
            else if (pID == 2)
            {
               // komaIdou.checkMasu(komaNaru, komaShu, pID);
            }
        }
        else if(mouse == 3)
        {
            if (masuNum != nowMasuNum)
            {
                if (pID == 1)
                {

                    pID = 2;
                    PlayerPrefs.SetInt("pID", pID);
                    Debug.Log("2pのターン");
                    turn++;
                    PlayerPrefs.SetInt("turn", turn);
                    return;
                }
                else if (pID == 2)
                {
                    pID = 1;
                    PlayerPrefs.SetInt("pID", pID);
                    Debug.Log("1pのターン");
                    turn++;
                    PlayerPrefs.SetInt("turn", turn);
                    return;
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}

