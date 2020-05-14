using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //カメラのプレイヤーごとによる分割
    public enum MultiPlayerCamera
    {
        player1,
        player2,
        player3,
        player4
    };

    public MultiPlayerCamera cameraMode;

    public Camera player1Camera;
    public Camera player2Camera;
    public Camera player3Camera;
    public Camera player4Camera;


    private int playerNumber;


    private GameObject GetPlayer;
    private GetPlayer GetPlayerScript;


    // Start is called before the first frame update
    void Start()
    {
        //GetPlayerから参加人数を取得（仮）
        GetPlayer = GameObject.Find("SurvivalModeManager");
        GetPlayerScript = GetPlayer.GetComponent<GetPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerNumber = GetPlayerScript.playerNumber;

        if (playerNumber == 1)
        {
            cameraMode = MultiPlayerCamera.player1;
        }
        else if (playerNumber == 2)
        {
            cameraMode = MultiPlayerCamera.player2;
        }
        else if (playerNumber == 3)
        {
            cameraMode = MultiPlayerCamera.player3;
        }
        else if (playerNumber == 4)
        {
            cameraMode = MultiPlayerCamera.player4;
        }


        //1プレイヤー時の画面分割(本来は使わないが確認のため）
        if (cameraMode == MultiPlayerCamera.player1)
        {
            player1Camera.gameObject.SetActive(true);
            player2Camera.gameObject.SetActive(false);
            player3Camera.gameObject.SetActive(false);
            player4Camera.gameObject.SetActive(false);

            player1Camera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            player2Camera.rect = new Rect(0.0f, 0.0f, 0.0f, 1.0f);
            player3Camera.rect = new Rect(0.0f, 0.0f, 0.0f, 1.0f);
            player4Camera.rect = new Rect(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //2プレイヤー時の画面分割
        else if (cameraMode == MultiPlayerCamera.player2)
        {
            player1Camera.gameObject.SetActive(true);
            player2Camera.gameObject.SetActive(true);
            player3Camera.gameObject.SetActive(false);
            player4Camera.gameObject.SetActive(false);

            player1Camera.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
            player2Camera.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
            player3Camera.rect = new Rect(0.0f, 0.0f, 0.0f, 1.0f);
            player4Camera.rect = new Rect(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //3プレイヤー時の画面分割
        else if (cameraMode == MultiPlayerCamera.player3)
        {
            player1Camera.gameObject.SetActive(true);
            player2Camera.gameObject.SetActive(true);
            player3Camera.gameObject.SetActive(true);
            player4Camera.gameObject.SetActive(false);

            player1Camera.rect = new Rect(0.0f, 0.0f, 0.333f, 1.0f);
            player2Camera.rect = new Rect(0.333f, 0.0f, 0.333f, 1.0f);
            player3Camera.rect = new Rect(0.666f, 0.0f, 0.334f, 1.0f);
            player4Camera.rect = new Rect(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //4プレイヤー時の画面分割
        else if (cameraMode == MultiPlayerCamera.player4)
        {
            player1Camera.gameObject.SetActive(true);
            player2Camera.gameObject.SetActive(true);
            player3Camera.gameObject.SetActive(true);
            player4Camera.gameObject.SetActive(true);

            player1Camera.rect = new Rect(0.0f, 0.0f, 0.25f, 1.0f);
            player2Camera.rect = new Rect(0.25f, 0.0f, 0.25f, 1.0f);
            player3Camera.rect = new Rect(0.5f, 0.0f, 0.25f, 1.0f);
            player4Camera.rect = new Rect(0.75f, 0.0f, 0.25f, 1.0f);
        }
    }
}
