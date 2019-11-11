using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class komaIdou : MonoBehaviour
{
    MasuHandler masuHandler;
    KomaModel komaModel;
    Mouse mouse;
    MeshRenderer meshRenderer;
    SpriteRenderer spriteRenderer;
    public Sprite[] mass;
    public GameObject[] Masu;
    int masu;

    public int[] movablemasu;
    public int[] masInfo;

    private void Start()
    {
        masuHandler = GameObject.Find("MasuHandler").GetComponent<MasuHandler>();
        mouse = GetComponent<Mouse>();
        int i;
        movablemasu = new int[72];
        for (i = 0; i < movablemasu.Length; i++)
        {
            movablemasu[i] = 0;
        }
        masInfo = new int[37];
        int f;
        for (f = 1; f < 37; f++)
        {
            masInfo[f] = 0;
        }
    }

    public void checkMasu(bool Naru,int Shu,int currentPlayer)
    {
        movablemasu = new int[72];
        if(Naru == false && Shu == 0 &&  currentPlayer == 1)//歩の場合
        {
            if(masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for(i = 1; i < 36;　i++)
                {
                        movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }                
            }
            else if(masuHandler.masuNum >= 7)
            {
                int i;
                i = masuHandler.masuNum - 6;
                movablemasu[i] = 1;
                Masu[i].SetActive(true);
                
                
            }
        }
        if (Naru == false && Shu == 0 && currentPlayer == 2)//2p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 36; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else if (masuHandler.masuNum <= 30)
            {
                int i;
                i = masuHandler.masuNum + 6;
                movablemasu[i] = 1;
                Masu[i].SetActive(true);


            }
        }
        if (Naru == true && Shu == 0 && currentPlayer == 1|| Naru == true && Shu == 2 && currentPlayer == 1)//成り歩の場合1p
        {
            if (masuHandler.masuNum < 7)//上段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);

                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int j = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;

                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {

                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum + 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
            }
            else if (masuHandler.masuNum > 30)//下段にいるとき
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    int n = masuHandler.masuNum + 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[n] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[n].SetActive(true);
                }

            }

        }
        else if (Naru == true && Shu == 0 && currentPlayer == 2 || Naru == true && Shu == 2 && currentPlayer == 2)//成り歩の場合2p
        {
            if (masuHandler.masuNum > 30)//下段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);

                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int j = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;

                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {

                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum - 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
            }
            else if (masuHandler.masuNum < 7)//上段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    int l = masuHandler.masuNum - 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    int l = masuHandler.masuNum - 1;
                    int n = masuHandler.masuNum - 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[n] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[n].SetActive(true);
                }
            }
        }
        if (Naru == false && Shu == 1 && currentPlayer == 1 || Naru == true && Shu == 1 && currentPlayer == 1)//金の場合1p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 36; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else if (masuHandler.masuNum < 7)//上段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);

                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int j = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;

                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {

                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum + 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
            }
            else if (masuHandler.masuNum > 30)//下段にいるとき
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum + 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum - 1;
                    int n = masuHandler.masuNum + 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[n] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[n].SetActive(true);
                }

            }
        }
        if (Naru == false && Shu == 1 && currentPlayer == 2 || Naru == true && Shu == 1 && currentPlayer == 2)//金の場合2p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 36; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else if (masuHandler.masuNum > 30)//下段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);

                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 1;
                    int j = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;

                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {

                    int k = masuHandler.masuNum - 1;
                    int j = masuHandler.masuNum - 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
            }
            else if (masuHandler.masuNum < 7)//上段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 6;
                    int j = masuHandler.masuNum + 7;
                    int m = masuHandler.masuNum + 1;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum + 5;
                    int k = masuHandler.masuNum + 6;
                    int l = masuHandler.masuNum - 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    int l = masuHandler.masuNum - 1;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 6;
                    int j = masuHandler.masuNum + 7;
                    int m = masuHandler.masuNum + 1;
                    int n = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum + 5;
                    int k = masuHandler.masuNum + 6;
                    int l = masuHandler.masuNum - 1;
                    int n = masuHandler.masuNum - 6;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[n] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[n].SetActive(true);
                }
            }
        }
        if (Naru == false && Shu == 2 && currentPlayer == 1)//銀の場合1p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 36; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else if (masuHandler.masuNum < 7)//上段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int k = masuHandler.masuNum + 7;    
                    movablemasu[i] = 1;    
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[k].SetActive(true);

                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 7;
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {

                    int k = masuHandler.masuNum + 5;
                    movablemasu[k] = 1;
                    Masu[k].SetActive(true);
                }
            }
            else if (masuHandler.masuNum > 30)//下段にいるとき
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum + 5;
                    int m = masuHandler.masuNum + 7;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int j = masuHandler.masuNum - 6;
                    int m = masuHandler.masuNum + 7;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum - 6;
                    int k = masuHandler.masuNum - 7;
                    int l = masuHandler.masuNum + 5;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                }

            }
        }
        if (Naru == false && Shu == 2 && currentPlayer == 2)//銀の場合2p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 36; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else if (masuHandler.masuNum > 30)//下段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum - 5;
                    int k = masuHandler.masuNum - 7;
                    movablemasu[i] = 1;
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[k].SetActive(true);

                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int j = masuHandler.masuNum - 5;
                    movablemasu[j] = 1;
                    Masu[j].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {

                    int k = masuHandler.masuNum - 7;
                    movablemasu[k] = 1;
                    Masu[k].SetActive(true);
                }
            }
            else if (masuHandler.masuNum < 7)//上段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 7;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 5;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 6 == 2 || masuHandler.masuNum % 6 == 3 || masuHandler.masuNum % 6 == 4 || masuHandler.masuNum % 6 == 5)//真ん中にいるとき
                {
                    Debug.Log("2pginn");
                    int i = masuHandler.masuNum + 5;
                    int j = masuHandler.masuNum + 6;
                    int k = masuHandler.masuNum + 7;
                    int l = masuHandler.masuNum - 5;
                    int m = masuHandler.masuNum - 7;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[l] = 1;
                    movablemasu[m] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[l].SetActive(true);
                    Masu[m].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 1)//左端にいるとき
                {
                    int i = masuHandler.masuNum + 6;
                    int j = masuHandler.masuNum + 7;
                    int n = masuHandler.masuNum - 5;
                    movablemasu[i] = 1;
                    movablemasu[j] = 1;
                    movablemasu[n] = 1;
                    Masu[i].SetActive(true);
                    Masu[j].SetActive(true);
                    Masu[n].SetActive(true);
                }
                else if (masuHandler.masuNum % 6 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    int j = masuHandler.masuNum + 5;
                    int k = masuHandler.masuNum + 6;
                    int n = masuHandler.masuNum - 7;
                    movablemasu[j] = 1;
                    movablemasu[k] = 1;
                    movablemasu[n] = 1;
                    Masu[j].SetActive(true);
                    Masu[k].SetActive(true);
                    Masu[n].SetActive(true);
                }
            }
        }
        if (Naru == false && Shu == 3 && currentPlayer == 1)//桂馬の場合1p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 37; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else if(masuHandler.masuNum > 7 && masuHandler.masuNum % 6 == 1 && masuHandler.masuNum != 37)
            {
                int i = masuHandler.masuNum - 11;
                movablemasu[i] = 1;
                Masu[i].SetActive(true);
            }
            else if (masuHandler.masuNum > 12 && masuHandler.masuNum % 6 == 0)
            {
                int i = masuHandler.masuNum - 13;
                movablemasu[i] = 1;
                Masu[i].SetActive(true);
            }
            else if(masuHandler.masuNum < 12)
            {
            }
            else
            {
                int i = masuHandler.masuNum - 11;
                int j = masuHandler.masuNum - 13;
                movablemasu[i] = 1;
                movablemasu[j] = 1;
                Masu[i].SetActive(true);
                Masu[j].SetActive(true);
            }
        }
        if (Naru == false && Shu == 3 && currentPlayer == 2)//桂馬の場合2p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 37; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else if (masuHandler.masuNum > 7 && masuHandler.masuNum % 6 == 1 && masuHandler.masuNum != 37)
            {
                int i = masuHandler.masuNum + 13;
                movablemasu[i] = 1;
                Masu[i].SetActive(true);
            }
            else if (masuHandler.masuNum > 12 && masuHandler.masuNum % 6 == 0)
            {
                int i = masuHandler.masuNum + 11;
                movablemasu[i] = 1;
                Masu[i].SetActive(true);
            }
            else if (masuHandler.masuNum > 24)
            {
            }
            else
            {
                int i = masuHandler.masuNum + 11;
                int j = masuHandler.masuNum + 13;
                movablemasu[i] = 1;
                movablemasu[j] = 1;
                Masu[i].SetActive(true);
                Masu[j].SetActive(true);
            }
        }
        if (Naru == false && Shu == 4 && currentPlayer == 1)//香車の場合1p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 37; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else 
            {
                int i = masuHandler.masuNum;
                while( i >= 0)
                {
                    i = i - 6;
                    if(i < 0)
                    {
                        break;
                    }
                    if (masInfo[i] == 1 && currentPlayer == 1)
                    {
                        break;
                    }
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                    if (masInfo[i] == 2 && currentPlayer == 1)
                    {
                        break;
                    }
                }
            }
        }
        if (Naru == false && Shu == 4 && currentPlayer == 2)//香車の場合2p
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i > 25; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else
            {
                int i = masuHandler.masuNum;
                while (i <= 36)
                {
                    i = i + 6;
                    if (i > 36)
                    {
                        break;
                    }
                    if (masInfo[i] == 2 && currentPlayer == 2)
                    {
                        break;
                    }
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                    if (masInfo[i] == 1 && currentPlayer == 2)
                    {
                        break;
                    }
                }
            }
        }
        if (Naru == false && Shu == 5 && currentPlayer == 1 || Naru == false && Shu == 5 && currentPlayer == 2)//飛車の場合1p & 2p


        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i > 37; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }
            }
            else
            {
                bool nex1 = true;
                bool nex2 = true;
                bool nex3 = true;
                bool nex4 = true;
                int i;
                for(i = 36; i > 0; i--)
                {
                    if(masuHandler.masuNum %6 == 0)
                    {
                        if (masuHandler.masuNum /6  == (i + 6) / 6 )
                        {
                            if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                            {
                                nex1 = false;
                            }
                            if(nex1 == true)
                            {
                                movablemasu[i] = 1;
                                Masu[i].SetActive(true);
                            }

                            if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                            {
                                nex1 = false;
                            }

                        }
                        if (masuHandler.masuNum % 6 == i % 6)
                        {
                            if (masuHandler.masuNum > i)
                            {
                                if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                                {
                                    nex3 = false;
                                }
                                if (nex3 == true)
                                {
                                    movablemasu[i] = 1;
                                    Masu[i].SetActive(true);
                                }

                                if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                                {
                                    nex3 = false;
                                }

                            }
                            if (masuHandler.masuNum < i)
                            {
                                movablemasu[i] = 1;
                                Masu[i].SetActive(true);
                                if (masInfo[i] == 1 && currentPlayer == 1)
                                {
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                        movablemasu[i] = 0;
                                        Masu[i].SetActive(false);
                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 30)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                                if (masInfo[i] == 2 && currentPlayer == 2)
                                {
                                    if (i - masuHandler.masuNum == 30)
                                    {
                                        movablemasu[i] = 0;
                                        Masu[i].SetActive(false);
                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                                if (masInfo[i] == 2 && currentPlayer == 1)
                                {
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 30)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                                if (masInfo[i] == 1 && currentPlayer == 2)
                                {
                                    if (i - masuHandler.masuNum == 30)
                                    {

                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (masuHandler.masuNum / 6 == (i - 1) / 6 )
                        {
                            if (masuHandler.masuNum < i)
                            {
                                movablemasu[i] = 1;
                                Masu[i].SetActive(true);
                                if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                                {
                                    if (i - masuHandler.masuNum == 5)
                                    {
                                        movablemasu[i] = 0;
                                        Masu[i].SetActive(false);
                                    }
                                    if (i - masuHandler.masuNum == 4)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 3)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);
                                        movablemasu[i + 2] = 0;
                                        Masu[i + 2].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 2)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);
                                        movablemasu[i + 2] = 0;
                                        Masu[i + 2].SetActive(false);
                                        movablemasu[i + 3] = 0;
                                        Masu[i + 3].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 1)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);
                                        movablemasu[i + 2] = 0;
                                        Masu[i + 2].SetActive(false);
                                        movablemasu[i + 3] = 0;
                                        Masu[i + 3].SetActive(false);
                                        movablemasu[i + 4] = 0;
                                        Masu[i + 4].SetActive(false);
                                        movablemasu[i + 4] = 0;
                                        Masu[i + 4].SetActive(false);
                                    }
                                }
                                if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                                {
                                    if (i - masuHandler.masuNum == 4)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 3)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);
                                        movablemasu[i + 2] = 0;
                                        Masu[i + 2].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 2)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);
                                        movablemasu[i + 2] = 0;
                                        Masu[i + 2].SetActive(false);
                                        movablemasu[i + 3] = 0;
                                        Masu[i + 3].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 1)
                                    {
                                        movablemasu[i + 1] = 0;
                                        Masu[i + 1].SetActive(false);
                                        movablemasu[i + 2] = 0;
                                        Masu[i + 2].SetActive(false);
                                        movablemasu[i + 3] = 0;
                                        Masu[i + 3].SetActive(false);
                                        movablemasu[i + 4] = 0;
                                        Masu[i + 4].SetActive(false);
                                        movablemasu[i + 4] = 0;
                                        Masu[i + 4].SetActive(false);
                                    }
                                }
                            }
                            if (masuHandler.masuNum > i)
                            {
                                if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                                {
                                    nex2 = false;
                                }
                                if (nex2 == true)
                                {
                                    movablemasu[i] = 1;
                                    Masu[i].SetActive(true);
                                    Debug.Log(i + "dayo");
                                }
                                if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                                {
                                    nex2 = false;
                                }
                            }
                          
                        }
                        if (masuHandler.masuNum % 6 == i % 6)
                        {
                            if (masuHandler.masuNum > i)
                            {
                                if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                                {
                                    nex1 = false;
                                }
                                if (nex1 == true)
                                {
                                    movablemasu[i] = 1;
                                    Masu[i].SetActive(true);
                                }

                                if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                                {
                                    nex1 = false;
                                }

                            }
                            if (masuHandler.masuNum < i)
                            {
                                movablemasu[i] = 1;
                                Masu[i].SetActive(true);
                                if (masInfo[i] == 1 && currentPlayer == 1 )
                                {
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                        movablemasu[i] = 0;
                                        Masu[i].SetActive(false);
                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 30)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                                if (masInfo[i] == 2 && currentPlayer == 2)
                                {
                                    if (i - masuHandler.masuNum == 30)
                                    {
                                        movablemasu[i] = 0;
                                        Masu[i].SetActive(false);
                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        Debug.Log(i + 18 + "suge");
                                        Debug.Log(movablemasu.Length);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                                if (masInfo[i] == 2 && currentPlayer == 1)
                                {
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 30)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                                if (masInfo[i] == 1 && currentPlayer == 2)
                                {
                                    if (i - masuHandler.masuNum == 30)
                                    {

                                    }
                                    if (i - masuHandler.masuNum == 24)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 18)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 12)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);

                                    }
                                    if (i - masuHandler.masuNum == 6)
                                    {
                                        movablemasu[i + 6] = 0;
                                        Masu[i + 6].SetActive(false);
                                        movablemasu[i + 12] = 0;
                                        Masu[i + 12].SetActive(false);
                                        movablemasu[i + 18] = 0;
                                        Masu[i + 18].SetActive(false);
                                        movablemasu[i + 24] = 0;
                                        Masu[i + 24].SetActive(false);
                                        movablemasu[i + 30] = 0;
                                        Masu[i + 30].SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                  
                }
            }
        }
        if (Naru == true && Shu == 5 && currentPlayer == 1 || Naru == true && Shu == 5 && currentPlayer == 2)//飛車成りの場合1p & 2p
        {
            bool nex1 = true;
            bool nex2 = true;
            bool nex3 = true;
            int i;
            for (i = 36; i > 0; i--)
            {
                if (masuHandler.masuNum % 6 == 0)
                {
                    if (masuHandler.masuNum / 6 == (i + 6) / 6)
                    {
                        if (masInfo[i] == 1 && currentPlayer == 1)
                        {
                            nex1 = false;
                        }
                        if (nex1 == true)
                        {
                            movablemasu[i] = 1;
                            Masu[i].SetActive(true);
                        }

                        if (masInfo[i] == 2 && currentPlayer == 1)
                        {
                            nex1 = false;
                        }

                    }
                    if (masuHandler.masuNum % 6 == i % 6)
                    {
                        if (masuHandler.masuNum > i)
                        {
                            if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                            {
                                nex3 = false;
                            }
                            if (nex3 == true)
                            {
                                movablemasu[i] = 1;
                                Masu[i].SetActive(true);
                            }

                            if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                            {
                                nex3 = false;
                            }

                        }
                        if (masuHandler.masuNum < i)
                        {
                            movablemasu[i] = 1;
                            Masu[i].SetActive(true);
                            if (masInfo[i] == 1 && currentPlayer == 1)
                            {
                                if (i - masuHandler.masuNum == 6)
                                {
                                    movablemasu[i] = 0;
                                    Masu[i].SetActive(false);
                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 30)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                            if (masInfo[i] == 2 && currentPlayer == 2)
                            {
                                if (i - masuHandler.masuNum == 30)
                                {
                                    movablemasu[i] = 0;
                                    Masu[i].SetActive(false);
                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 6)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                            if (masInfo[i] == 2 && currentPlayer == 1)
                            {
                                if (i - masuHandler.masuNum == 6)
                                {
                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 30)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                            if (masInfo[i] == 1 && currentPlayer == 2)
                            {
                                if (i - masuHandler.masuNum == 30)
                                {

                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 6)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (masuHandler.masuNum / 6 == (i - 1) / 6)
                    {
                        if (masuHandler.masuNum < i)
                        {
                            movablemasu[i] = 1;
                            Masu[i].SetActive(true);
                            if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                            {
                                if (i - masuHandler.masuNum == 5)
                                {
                                    movablemasu[i] = 0;
                                    Masu[i].SetActive(false);
                                }
                                if (i - masuHandler.masuNum == 4)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 3)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);
                                    movablemasu[i + 2] = 0;
                                    Masu[i + 2].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 2)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);
                                    movablemasu[i + 2] = 0;
                                    Masu[i + 2].SetActive(false);
                                    movablemasu[i + 3] = 0;
                                    Masu[i + 3].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 1)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);
                                    movablemasu[i + 2] = 0;
                                    Masu[i + 2].SetActive(false);
                                    movablemasu[i + 3] = 0;
                                    Masu[i + 3].SetActive(false);
                                    movablemasu[i + 4] = 0;
                                    Masu[i + 4].SetActive(false);
                                    movablemasu[i + 4] = 0;
                                    Masu[i + 4].SetActive(false);
                                }
                            }
                            if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                            {
                                if (i - masuHandler.masuNum == 4)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 3)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);
                                    movablemasu[i + 2] = 0;
                                    Masu[i + 2].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 2)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);
                                    movablemasu[i + 2] = 0;
                                    Masu[i + 2].SetActive(false);
                                    movablemasu[i + 3] = 0;
                                    Masu[i + 3].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 1)
                                {
                                    movablemasu[i + 1] = 0;
                                    Masu[i + 1].SetActive(false);
                                    movablemasu[i + 2] = 0;
                                    Masu[i + 2].SetActive(false);
                                    movablemasu[i + 3] = 0;
                                    Masu[i + 3].SetActive(false);
                                    movablemasu[i + 4] = 0;
                                    Masu[i + 4].SetActive(false);
                                    movablemasu[i + 4] = 0;
                                    Masu[i + 4].SetActive(false);
                                }
                            }
                        }
                        if (masuHandler.masuNum > i)
                        {
                            if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                            {
                                nex2 = false;
                            }
                            if (nex2 == true)
                            {
                                movablemasu[i] = 1;
                                Masu[i].SetActive(true);

                            }
                            if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                            {
                                nex2 = false;
                            }
                        }

                    }
                    if (masuHandler.masuNum % 6 == i % 6)
                    {
                        if (masuHandler.masuNum > i)
                        {
                            if (masInfo[i] == 1 && currentPlayer == 1 || masInfo[i] == 2 && currentPlayer == 2)
                            {
                                nex1 = false;
                            }
                            if (nex1 == true)
                            {
                                movablemasu[i] = 1;
                                Masu[i].SetActive(true);
                            }

                            if (masInfo[i] == 2 && currentPlayer == 1 || masInfo[i] == 1 && currentPlayer == 2)
                            {
                                nex1 = false;
                            }

                        }
                        if (masuHandler.masuNum < i)
                        {
                            movablemasu[i] = 1;
                            Masu[i].SetActive(true);
                            if (masInfo[i] == 1 && currentPlayer == 1)
                            {
                                if (i - masuHandler.masuNum == 6)
                                {
                                    movablemasu[i] = 0;
                                    Masu[i].SetActive(false);
                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 30)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                            if (masInfo[i] == 2 && currentPlayer == 2)
                            {
                                if (i - masuHandler.masuNum == 30)
                                {
                                    movablemasu[i] = 0;
                                    Masu[i].SetActive(false);
                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 6)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                            if (masInfo[i] == 2 && currentPlayer == 1)
                            {
                                if (i - masuHandler.masuNum == 6)
                                {
                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 30)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                            if (masInfo[i] == 1 && currentPlayer == 2)
                            {
                                if (i - masuHandler.masuNum == 30)
                                {

                                }
                                if (i - masuHandler.masuNum == 24)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 18)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 12)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);

                                }
                                if (i - masuHandler.masuNum == 6)
                                {
                                    movablemasu[i + 6] = 0;
                                    Masu[i + 6].SetActive(false);
                                    movablemasu[i + 12] = 0;
                                    Masu[i + 12].SetActive(false);
                                    movablemasu[i + 18] = 0;
                                    Masu[i + 18].SetActive(false);
                                    movablemasu[i + 24] = 0;
                                    Masu[i + 24].SetActive(false);
                                    movablemasu[i + 30] = 0;
                                    Masu[i + 30].SetActive(false);
                                }
                            }
                        }
                    }
                }

            }
            int k;
            for (k = 36; k > 0; k--)
            {
                if (k == masuHandler.masuNum - 5 || k == masuHandler.masuNum + 5 || k == masuHandler.masuNum + 7 || k == masuHandler.masuNum - 7)
                {
                    movablemasu[k] = 1;
                    Masu[k].SetActive(true);
                }

            }
            if (masuHandler.masuNum == 31)
            {
                movablemasu[24] = 0;
                Masu[24].SetActive(false);
            }
            if (masuHandler.masuNum == 25)
            {
                movablemasu[18] = 0;
                Masu[18].SetActive(false);
            }
            if (masuHandler.masuNum == 19)
            {
                movablemasu[12] = 0;
                Masu[12].SetActive(false);
            }
            if (masuHandler.masuNum == 13)
            {
                movablemasu[6] = 0;
                Masu[6].SetActive(false);
            }
            if (masuHandler.masuNum == 24)
            {
                movablemasu[31] = 0;
                Masu[31].SetActive(false);
            }
            if (masuHandler.masuNum == 18)
            {
                movablemasu[25] = 0;
                Masu[25].SetActive(false);
            }
            if (masuHandler.masuNum == 12)
            {
                movablemasu[19] = 0;
                Masu[19].SetActive(false);
            }
            if (masuHandler.masuNum == 6)
            {
                movablemasu[13] = 0;
                Masu[13].SetActive(false);
            }

        }
        if (Naru == false && Shu == 6 && currentPlayer == 1 || Naru == false && Shu == 6 && currentPlayer == 2)//角の場合1p & 2p{
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i > 37; i++)
                {
                    movablemasu[i] = 1;
                    Masu[i].SetActive(true);
                }

            }
            else
            {
                int i;
                for (i = 1; i < 37; i++)
                {
                    int k;
                    int j;
                    int l;
                    if (masuHandler.masuNum % 7 == i % 7 || masuHandler.masuNum % 5 == i % 5)
                    {
                        movablemasu[i] = 1;
                        Masu[i].SetActive(true);
                    }
                    if (masuHandler.masuNum == 1 || masuHandler.masuNum == 36)
                    {
                        for (k = 1; k < 7; k++)
                        {
                            j = k * 5 + 1;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 2)
                    {
                        for (k = 1; k < 7; k++)
                        {
                            j = k * 5 + 7;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 3)
                    {
                        for (k = 1; k < 7; k++)
                        {
                            j = k * 5 + 13;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 4)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 24;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 7 + 25;
                            if (l > 36)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 5)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 30;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 7 + 19;
                            if (l > 36)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 6)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 13;

                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 7 + 1;
                            if (l > 36)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 7)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 12;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 8)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 18;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 9)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 24;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 10)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 30;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 11)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 25;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 7 + 1;
                            if (l > 36)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 12)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 19;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 5 + 2;
                            if (l > 7)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 13)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 18;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 6;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 14)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 24;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 15)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 30;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 16)
                    {
                        j = 1;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                        j = 36;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 17)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 2;
                            if (j > 7)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 18)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 25;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 5 + 3;
                            if (l > 13)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 19)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 24;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 7 + 5;
                            if (l > 12)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 20)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 30;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 6;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 21)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 1;
                            if (j > 36)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 22)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 2;
                            if (j > 7)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 23)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 3;
                            if (j > 13)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 24)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 4;
                            if (j > 19)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 25)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 4;
                            if (j > 18)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 5 + 30;
                            if (l > 36)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 26)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 5;
                            if (j > 12)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 7 + 1;
                            if (l > 36)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 27)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 2;
                            if (j > 7)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 6;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 28)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 3;
                            if (j > 13)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 29)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 4;
                            if (j > 19)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 30)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 5;
                            if (j > 25)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 31)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 3;
                            if (j > 24)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 7 + 1;
                            if (l > 36)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 32)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 4;
                            if (j > 18)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 5 + 2;
                            if (l > 7)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 33)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 7 + 5;
                            if (j > 12)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);

                        }
                        for (k = 0; k < 7; k++)
                        {
                            l = k * 5 + 3;
                            if (l > 13)
                            {
                                break;
                            }

                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                    if (masuHandler.masuNum == 34)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 4;
                            if (j > 19)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 6;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 35)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 5;
                            if (j > 25)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                    }
                }
                int g;
                bool kaku1 = false;
                bool kaku2 = false;
                for (g = 36; g > 0; g--)
                {
                    if(masuHandler.masuNum % 7 == g % 7)
                    {
                        if (masuHandler.masuNum < g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2 || masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                if(g - masuHandler.masuNum == 28)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 21)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                    movablemasu[g + 14] = 0;
                                    Masu[g + 14].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 14)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                    movablemasu[g + 14] = 0;
                                    Masu[g + 14].SetActive(false);
                                    movablemasu[g + 21] = 0;
                                    Masu[g + 21].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 7)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                    movablemasu[g + 14] = 0;
                                    Masu[g + 14].SetActive(false);
                                    movablemasu[g + 21] = 0;
                                    Masu[g + 21].SetActive(false);
                                    movablemasu[g + 28] = 0;
                                    Masu[g + 28].SetActive(false);
                                }
                            }
                        }
                        if (masuHandler.masuNum > g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2)
                            {
                                kaku1 = true;
                                Debug.Log("ha");
                            }
                            if (kaku1 == true)
                            {
                                Debug.Log("da");
                                movablemasu[g] = 0;
                                Masu[g].SetActive(false);
                            }
                            if (masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                kaku1 = true;
                                Debug.Log("ne");
                            }
                        }
                    }
                    if (masuHandler.masuNum % 5 == g % 5)
                    {
                        if (masuHandler.masuNum < g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2 || masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                if (g - masuHandler.masuNum == 20)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 15)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                    movablemasu[g + 10] = 0;
                                    Masu[g + 10].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 10)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                    movablemasu[g + 10] = 0;
                                    Masu[g + 10].SetActive(false);
                                    movablemasu[g + 15] = 0;
                                    Masu[g + 15].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 5)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                    movablemasu[g + 10] = 0;
                                    Masu[g + 10].SetActive(false);
                                    movablemasu[g + 15] = 0;
                                    Masu[g + 15].SetActive(false);
                                    movablemasu[g + 20] = 0;
                                    Masu[g + 20].SetActive(false);
                                }
                            }
                        }
                        if (masuHandler.masuNum > g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2)
                            {
                                kaku2 = true;
                            }
                            if (kaku2)
                            {
                                movablemasu[g] = 0;
                                Masu[g].SetActive(false);
                            }
                            if (masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                kaku2 = true;
                            }
                        }
                    }




                }
            }
        }
        if (Naru == true && Shu == 6 && currentPlayer == 1 || Naru == true && Shu == 6 && currentPlayer == 2)//角成りの場合1p & 2p{
            {
                if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
                {
                    int i;
                    for (i = 1; i > 37; i++)
                    {
                        movablemasu[i] = 1;
                    }

                }
                else
                {
                    int i;
                    for (i = 1; i < 37; i++)
                    {
                        int k;
                        int j;
                        int l;
                        if (masuHandler.masuNum % 7 == i % 7 || masuHandler.masuNum % 5 == i % 5)
                        {
                            movablemasu[i] = 1;
                            Masu[i].SetActive(true);
                        }
                    if (i == masuHandler.masuNum - 6 || i == masuHandler.masuNum + 1 || i == masuHandler.masuNum + 6 || i == masuHandler.masuNum - 1)
                    {
                        movablemasu[i] = 1;
                        Masu[i].SetActive(true);
                    }
                    if (masuHandler.masuNum == 1 || masuHandler.masuNum == 36)
                        {
                            for (k = 1; k < 7; k++)
                            {
                                j = k * 5 + 1;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 2)
                        {
                            for (k = 1; k < 7; k++)
                            {
                                j = k * 5 + 7;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 3)
                        {
                            for (k = 1; k < 7; k++)
                            {
                                j = k * 5 + 13;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            j = 31;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 4)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 24;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 7 + 25;
                                if (l > 36)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                            j = 31;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 5)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 30;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 7 + 19;
                                if (l > 36)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                            j = 31;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 6)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 13;

                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 7 + 1;
                                if (l > 36)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                            j = 7;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 7)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 12;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                             j = 6;
                             movablemasu[j] = 0;
                             Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 8)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 18;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 9)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 24;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 10)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 30;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            j = 31;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 11)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 25;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 7 + 1;
                                if (l > 36)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 12)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 19;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 5 + 2;
                                if (l > 7)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                             j = 13;
                             movablemasu[j] = 0;
                             Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 13)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 18;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            j = 6;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                            j = 12;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 14)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 24;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
  
                        }
                        if (masuHandler.masuNum == 15)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 30;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                    if (masuHandler.masuNum == 16)
                    {
                        j = 1;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                        j = 36;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 17)
                    {
                        for (k = 0; k < 7; k++)
                        {
                            j = k * 5 + 2;
                            if (j > 7)
                            {
                                break;
                            }

                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                    if (masuHandler.masuNum == 18)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 25;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 5 + 3;
                                if (l > 13)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        j = 19;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                        if (masuHandler.masuNum == 19)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 24;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 7 + 5;
                                if (l > 12)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        j = 18;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);

                    }
                        if (masuHandler.masuNum == 20)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 30;
                                if (j > 36)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            j = 6;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 21)
                        {
                        j = 1;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                        j = 36;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                        if (masuHandler.masuNum == 22)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 2;
                                if (j > 7)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 23)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 3;
                                if (j > 13)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 24)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 4;
                                if (j > 19)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            j = 31;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        j =25;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);

                    }
                        if (masuHandler.masuNum == 25)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 4;
                                if (j > 18)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 5 + 30;
                                if (l > 36)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        j = 24;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                        if (masuHandler.masuNum == 26)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 5;
                                if (j > 12)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 7 + 1;
                                if (l > 36)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 27)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 2;
                                if (j > 7)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            j = 6;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 28)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 3;
                                if (j > 13)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 29)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 4;
                                if (j > 19)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 30)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 5;
                                if (j > 25)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        j = 31;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                        if (masuHandler.masuNum == 31)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 3;
                                if (j > 24)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 7 + 1;
                                if (l > 36)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        j = 30;
                        movablemasu[j] = 0;
                        Masu[j].SetActive(false);
                    }
                        if (masuHandler.masuNum == 32)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 4;
                                if (j > 18)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 5 + 2;
                                if (l > 7)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 33)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 7 + 5;
                                if (j > 12)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);

                            }
                            for (k = 0; k < 7; k++)
                            {
                                l = k * 5 + 3;
                                if (l > 13)
                                {
                                    break;
                                }

                                movablemasu[l] = 0;
                                Masu[l].SetActive(false);
                            }
                        }
                        if (masuHandler.masuNum == 34)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 4;
                                if (j > 19)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                            j = 6;
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (masuHandler.masuNum == 35)
                        {
                            for (k = 0; k < 7; k++)
                            {
                                j = k * 5 + 5;
                                if (j > 25)
                                {
                                    break;
                                }

                                movablemasu[j] = 0;
                                Masu[j].SetActive(false);
                            }
                        }
                    }
                int g;
                bool kaku1 = false;
                bool kaku2 = false;
                for (g = 36; g > 0; g--)
                {
                    if (masuHandler.masuNum % 7 == g % 7)
                    {
                        if (masuHandler.masuNum < g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2 || masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                if (g - masuHandler.masuNum == 28)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 21)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                    movablemasu[g + 14] = 0;
                                    Masu[g + 14].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 14)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                    movablemasu[g + 14] = 0;
                                    Masu[g + 14].SetActive(false);
                                    movablemasu[g + 21] = 0;
                                    Masu[g + 21].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 7)
                                {
                                    movablemasu[g + 7] = 0;
                                    Masu[g + 7].SetActive(false);
                                    movablemasu[g + 14] = 0;
                                    Masu[g + 14].SetActive(false);
                                    movablemasu[g + 21] = 0;
                                    Masu[g + 21].SetActive(false);
                                    movablemasu[g + 28] = 0;
                                    Masu[g + 28].SetActive(false);
                                }
                            }
                        }
                        if (masuHandler.masuNum > g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2)
                            {
                                kaku1 = true;
                                Debug.Log("ha");
                            }
                            if (kaku1 == true)
                            {
                                Debug.Log("da");
                                movablemasu[g] = 0;
                                Masu[g].SetActive(false);
                            }
                            if (masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                kaku1 = true;
                                Debug.Log("ne");
                            }
                        }
                    }
                    if (masuHandler.masuNum % 5 == g % 5)
                    {
                        if (masuHandler.masuNum < g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2 || masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                if (g - masuHandler.masuNum == 20)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 15)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                    movablemasu[g + 10] = 0;
                                    Masu[g + 10].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 10)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                    movablemasu[g + 10] = 0;
                                    Masu[g + 10].SetActive(false);
                                    movablemasu[g + 15] = 0;
                                    Masu[g + 15].SetActive(false);
                                }
                                if (g - masuHandler.masuNum == 5)
                                {
                                    movablemasu[g + 5] = 0;
                                    Masu[g + 5].SetActive(false);
                                    movablemasu[g + 10] = 0;
                                    Masu[g + 10].SetActive(false);
                                    movablemasu[g + 15] = 0;
                                    Masu[g + 15].SetActive(false);
                                    movablemasu[g + 20] = 0;
                                    Masu[g + 20].SetActive(false);
                                }
                            }
                        }
                        if (masuHandler.masuNum > g)
                        {
                            if (masInfo[g] == 1 && currentPlayer == 1 || masInfo[g] == 2 && currentPlayer == 2)
                            {
                                kaku2 = true;
                            }
                            if (kaku2)
                            {
                                movablemasu[g] = 0;
                                Masu[g].SetActive(false);
                            }
                            if (masInfo[g] == 2 && currentPlayer == 1 || masInfo[g] == 1 && currentPlayer == 2)
                            {
                                kaku2 = true;
                            }
                        }
                    }




                }
            }
        }
        if (Shu == 7)//王の場合1p & 2p{
        {
            if (masuHandler.masuNum == 37 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i > 37; i++)
                {
                    movablemasu[i] = 1;
                }
            }
            else
            {
                int i;
                for (i = 1; i < 37; i++)
                {
                    int k;
                    int j;
                    int l;
                    if (i == masuHandler.masuNum - 6 || i == masuHandler.masuNum + 1 || i == masuHandler.masuNum + 6 || i == masuHandler.masuNum - 1||i == masuHandler.masuNum - 7 || i == masuHandler.masuNum + 7 || i == masuHandler.masuNum + 5 || i == masuHandler.masuNum - 5)
                    {
                        movablemasu[i] = 1;
                        Masu[i].SetActive(true);
                    }
                    if (masuHandler.masuNum % 6 == 1)
                    {
                        k = masuHandler.masuNum - 7;
                        j = masuHandler.masuNum - 1;
                        l = masuHandler.masuNum + 5;
                        if(k > 0)
                        {
                            movablemasu[k] = 0;
                            Masu[k].SetActive(false);
                        }
                        if (j > 0)
                        {
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (l > 0)
                        {
                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }

                    }
                    if (masuHandler.masuNum % 6 == 0)
                    {
                        k = masuHandler.masuNum - 5;
                        j = masuHandler.masuNum + 1;
                        l = masuHandler.masuNum + 7;
                        if (k > 0)
                        {
                            movablemasu[k] = 0;
                            Masu[k].SetActive(false);
                        }
                        if (j < 37)
                        {
                            movablemasu[j] = 0;
                            Masu[j].SetActive(false);
                        }
                        if (l < 37)
                        {
                            movablemasu[l] = 0;
                            Masu[l].SetActive(false);
                        }
                    }
                }
            }
        }
        int f;
        for (f = 1; f < 37; f++)//自分の駒がある場合動けない
        {
            if(masInfo[f] == 1 && currentPlayer == 1)
            {
                movablemasu[f] = 0;
                Masu[f].SetActive(false);
            }
            if (masInfo[f] == 2 && currentPlayer == 2)
            {
                movablemasu[f] = 0;
                Masu[f].SetActive(false);
            }
        }


    }
       

    public void ReSetMasu()//引数をリセットする
    {
        int i;
        movablemasu = new int[38];
        for (i = 0; i < movablemasu.Length; i++)
        {
            movablemasu[i] = 0;
        }
        int k;
        for (k = 1; k < Masu.Length; k++)
        {
            Masu[k].SetActive(false);
        }
    }
}

