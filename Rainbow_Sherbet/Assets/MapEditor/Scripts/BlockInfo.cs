using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Vector2 Pos;         //�� ��ġ

    public bool isStar;         //���� ���� ���Ѱ�����

    public BlockCase blockCase; //���� ���� ����

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
}
