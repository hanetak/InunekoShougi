using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mouse : Photon.MonoBehaviour
{
    MasuHandler masuHandler;
    KomaModel komaModel;
    DirectionDeterminator directionDeterminator;
    komaIdou komaIdou;

    public Transform[] spawnPoints;

    Collider2D m_ObjectCollider;
    GameObject[] koma1;
    GameObject[] koma2;

    public float xzahyou;
    public float yzahyou;
    float afx;
    float afy;
    public int KomaShu;
    public int KomaNaru;
    int[] masuM;

    public int pID;
    public int currentPlayer;
    int turn;
    int mouse;



    public AudioSource dog;
    public AudioSource cat;

    //マウスでドラッグするスクリプト

    private Vector3 screenPoint;
    private Vector3 offset;


    private void Start()
    {
        directionDeterminator = GameObject.Find("DirectionDeterminator").GetComponent<DirectionDeterminator>();
        masuHandler = GameObject.Find("MasuHandler").GetComponent<MasuHandler>();
        komaIdou = GameObject.Find("KomaIdou").GetComponent<komaIdou>();
        komaModel = GetComponent<KomaModel>();
        PlayerPrefs.SetInt("pID", 1);
        PlayerPrefs.SetInt("turn", 0);


    }

    void OnMouseDown()
    {
        komaIdou.ReSetMasu();//マスの色を消す
        turn = PlayerPrefs.GetInt("turn");
        pID = PlayerPrefs.GetInt("pID");
        Debug.Log("いま" + pID + "," + turn + "目です");
       if(gameObject.tag == "1koma")
        {
            currentPlayer = 1;
            Debug.Log("なう" + currentPlayer);
        }
        else
        {
            currentPlayer = 2;
            Debug.Log("なう" + currentPlayer);
        }
        
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        xzahyou = transform.position.x;
        yzahyou = transform.position.y;
        afx = xzahyou;
        afy = yzahyou;
        KomaShu = komaModel.cardIndex;
        KomaNaru = komaModel.komaBackIndex;
        mouse = 1;

        masuHandler.MasuCordinator(xzahyou, yzahyou, KomaShu, komaModel.naru, komaModel.komaNariField,mouse); //引数を加える。
        if(pID == currentPlayer)
        {
            komaIdou.checkMasu(komaModel.naru, KomaShu, currentPlayer);//駒の移動先をチェックする
        }
        m_ObjectCollider = GetComponent<BoxCollider2D>();
        m_ObjectCollider.isTrigger = false;

       

    }

    void OnMouseDrag()
    {
        if(pID == currentPlayer)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
            transform.position = currentPosition;
        }


    }

    void OnMouseUp()
    {

        if (pID == currentPlayer)
        {
            xzahyou = transform.position.x;
            yzahyou = transform.position.y;
            KomaShu = komaModel.cardIndex;
            KomaNaru = komaModel.komaBackIndex;
            mouse = 2;
            masuHandler.MasuCordinator(xzahyou, yzahyou, KomaShu, komaModel.naru, komaModel.komaNariField,mouse);
     
            m_ObjectCollider = GetComponent<BoxCollider2D>();
            m_ObjectCollider.isTrigger = true;

            directionDeterminator.ResetAll(masuHandler.masuNum);


            koma1 = GameObject.FindGameObjectsWithTag("1koma");
            koma2 = GameObject.FindGameObjectsWithTag("2koma");


            xzahyou = PlayerPrefs.GetFloat("x");//駒の移動先の位置を取得
            yzahyou = PlayerPrefs.GetFloat("y");

            masuM = komaIdou.movablemasu;
            int k;
            k = masuHandler.masuNum;
            Debug.Log(k + "dayo");
            if (masuM[k] == 1)
            {
                komaIdou.ReSetMasu();
                transform.position = new Vector3(xzahyou, yzahyou, -0.5f);//移動先に駒を移動
                komaIdou.masInfo[k] = currentPlayer;
                if(masuHandler.nowMasuNum!= 37)
                {
                    komaIdou.masInfo[masuHandler.nowMasuNum] = 0;
                }          
                Debug.Log(masuHandler.nowMasuNum + "+" +k);
                mouse = 3;
                if(currentPlayer == 1)
                {
                    if (masuHandler.masuNum <= 12)
                    {
                        komaModel.ToggleFace(2);//1pの駒がなる
                    }
                }
                if (currentPlayer == 2)
                {
                    if (masuHandler.masuNum >= 25)
                    {
                        komaModel.ToggleFace(2);
                    }
                }

                masuHandler.MasuCordinator(xzahyou, yzahyou, KomaShu, komaModel.naru, komaModel.komaNariField, mouse);
                int i, j;
                for (i = 0; i < koma1.Length; i++)
                {
                    for (j = 0; j < koma2.Length; j++)
                    {
                        if (koma1[i].transform.position.x == koma2[j].transform.position.x && koma1[i].transform.position.y == koma2[j].transform.position.y)
                        {
                            if (currentPlayer == 1)
                            {
                                Destroy(koma2[j]);
                            }
                            if (currentPlayer == 2)
                            {
                                Destroy(koma1[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                transform.position = new Vector3(afx, afy, -0.5f);//元の位置に戻す
            }
            
       
            
            

                

        }
    

     
        /*int i;
        for (i = 0; i < koma.Length; i++)
        {
            if (Mathf.Abs(koma[i].transform.position.x - xzahyou) <= 0.2f && Mathf.Abs(koma[i].transform.position.y - yzahyou) <= 0.2f && Mathf.Abs(koma[i].transform.position.x - xzahyou) != 0)
            {
                //Debug.Log(koma[i].transform.position.x - xzahyou);
                //Debug.Log(koma[i].transform.position.y - yzahyou);

                koma[i].GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);
                KomaModel komaModel = koma[i].GetComponent<KomaModel>();
                int j = komaModel.cardIndex;

                int index = PhotonNetwork.player.ID - 1;

                if (index > 1)
                {
                    index = 1;
                }

                PhotonNetwork.Destroy(koma[i]);

                if (j < 5 && PhotonNetwork.player.ID == 1)
                {
                    dog = GetComponent<AudioSource>();
                    dog.Play(0);

                    Vector3 temp = new Vector3(4.3f, -1.5f, -1.0f);//(-3.1f, 1.5f, -1.0f)
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("uchikoma", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
                else if (j < 5 && PhotonNetwork.player.ID != 1)
                {
                    cat = GetComponent<AudioSource>();
                    cat.Play(0);

                    Vector3 temp = new Vector3(-3.1f, 1.5f, -1.0f);
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("uchineko", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
                else if (j == 5 && PhotonNetwork.player.ID == 1)
                {
                    dog = GetComponent<AudioSource>();
                    dog.Play(0);

                    Vector3 temp = new Vector3(4.3f, -1.5f, -1.0f);//(-3.1f, 1.5f, -1.0f)
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("matatabi", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
                else if (j == 5 && PhotonNetwork.player.ID != 1)
                {
                    cat = GetComponent<AudioSource>();
                    cat.Play(0);

                    Vector3 temp = new Vector3(-3.1f, 1.5f, -1.0f);
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("hone", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
            }
        }*/
    }
}
