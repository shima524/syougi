using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��N���X

public class Piece : MonoBehaviour
{
    //�G��������
    //�ǂ��ɓ����邩
    public bool player = true;
    public Material playerMaterial, enemyMaterial;

    public bool[,] moveArea = new bool[3,3];

    public bool test;
    public int x, y;

    // Start is called before the first frame update
    void Start()
    {
        if (player)
        {
            this.GetComponent<Renderer>().material = playerMaterial;
        }
        else {
            this.GetComponent<Renderer>().material = enemyMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ��͈͂�\��
        if (test) {
            showMoveArea();
            test = false;
        }
    }

    //�ړ��͈͂�\��
    void showMoveArea() {
        string str = "";
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j< 3; j++)
            {
                if (moveArea[i, j]) {
                    str += "�Z";
                }
                else {
                    str += "�~";
                }
            }
            str += "\n";
        }
        Debug.Log(str);
    }

    public void Move(int x, int y)
    {
        this.transform.position = new Vector3(x-2.0f,y-3.5f,0);
        this.x = x;
        this.y = y;
    }
}
