using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class CSVReader : MonoBehaviour
{

    [SerializeField] public TextAsset _CsvFile;
    public TextAsset CsvFile
    {
        get => _CsvFile;
        set => _CsvFile = value;
    }

    public List<List<int>> _csvTypeNum = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
        //  ���[�_�[�̍쐬
        StringReader reader = new StringReader(CsvFile.text);

        List<string[]> csv_datas = new List<string[]>();
        while (reader.Peek() != -1)
        {
            //  ��s�ÂÓǂݍ��܂���
            string line = reader.ReadLine();
            //  ,�̋�؂�ŕ������ۑ�
            csv_datas.Add(line.Split(','));
        }

        //  ������̐��l���畁�ʂ̐��l�փp�[�T�[
        for (int y = 0; y < csv_datas.Count(); ++y)
        {
            List<int> wk = new List<int>();
            for (int x = 0; x < csv_datas[y].Count(); ++x)
            {
                int num = int.Parse(csv_datas[y][x]);
                wk.Add(num);
            }
            _csvTypeNum.Add(wk);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
