using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // SpriteRendererクラスを参照します。①（Cardmodelクラスが直接アタッチされているオブジェクトのクラスを参照void awakeの所とセット）

    public Sprite[] faces;　　// 外部から参照できる（インスペクターからいじれる）facesという表面のリストの宣言。
    public Sprite[] komaNaru;// 外部から参照できる（インスペクターからいじれる）cardBackという裏面の宣言。

    public int cardIndex;　// 外部から参照できるcardIndex という値の宣言。
    public int komaBackIndex;
    public bool naru;
    public int komaNariField;

    public void ToggleFace(int showFace)　//外部アクセス可能なToggleFaceというメソッドの定義　引数に真偽値としてshowFaceを取る。
    {

        if (showFace == 0)　// もし showface がtrueであれば、
        {
            spriteRenderer.sprite = faces[cardIndex];  //②で取得したspriteにfaces[与えられたインデックス値]をレンダーさせる。
            naru = false;
        }
        else
        {

                naru = true;

                if (cardIndex == 0)//歩の場合
                {
                spriteRenderer.sprite = komaNaru[0];
            }
                else if (cardIndex == 1)//金の場合
                {
                }
                else if (cardIndex == 2)//銀の場合
                {
                    spriteRenderer.sprite = komaNaru[1];
                }
                else if (cardIndex == 3)//桂馬の場合
                {
                    spriteRenderer.sprite = komaNaru[2];
                }
                else if (cardIndex == 4)//香車の場合
                {
                     spriteRenderer.sprite = komaNaru[3];
                }
            else if (cardIndex == 5)//飛車の場合
            {
                spriteRenderer.sprite = komaNaru[4];
            }
            else if (cardIndex == 6)//角の場合
            {
                spriteRenderer.sprite = komaNaru[5];
            }



        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //このスクリプトがアタッチされているオブジェクトのインスペクター上のspriteRendererを取得します。①とセット。②
        ToggleFace(0);
    }
}