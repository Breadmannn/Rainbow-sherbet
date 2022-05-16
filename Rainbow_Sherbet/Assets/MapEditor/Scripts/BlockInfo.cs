using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BlockCase
{
    NullBlock = 0,  //�ƹ��͵� X
    StartBlock,     //���ۺ�
    EndBlock,       //�� ��
    ColorBlock,     //�� ��
    ObstacleBlock   //��ֹ� ��
}

public class BlockInfo : MonoBehaviour
{ 
    public string BlockCode;    //�� ���� ����

    public Vector2 Pos = Vector2.zero;         //�� ��ġ

    //public bool isStar;         //���� ���� ���Ѱ�����

    public BlockCase blockCase; //���� ���� ����

    //�ӽ�
    public Material mat;        //���� ���� ���׸���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitBlock()
    {
        if(BlockCode[0] == 'N')
        {
            blockCase = BlockCase.NullBlock;
        }
        else if(BlockCode[0] == 'C')
        {
            blockCase = BlockCase.ColorBlock;
        }
        else if(BlockCode[0] == 'O')
        {
            blockCase = BlockCase.ObstacleBlock;
        }
    }

    //�� ��ġ ����
    public void SetBlockPos(Vector2 inputPos)
    {
        Pos.Set(inputPos.x, inputPos.y);
        Debug.Log(Pos.x + " : " + Pos.y);
        gameObject.transform.position = new Vector3(Pos.x, 0, Pos.y);
    }

    //�ʿ������ϰ�� ���콺�� ���� ��� �˼��ְ� ���׸��� �����ѵ�
    //���׸��� ���������� ���� �ϴ� �κ�
    private void OnMouseExit()
    {
        if (SceneManager.GetActiveScene().name == "MapEditor")
        {
            Material[] tempMat = gameObject.GetComponent<MeshRenderer>().materials;
            Color tempColor = mat.color;
            tempMat[0].color = tempColor;
            gameObject.GetComponent<MeshRenderer>().materials = tempMat;
        }
    }
}
