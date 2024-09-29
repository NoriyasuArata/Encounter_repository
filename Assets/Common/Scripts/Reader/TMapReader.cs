using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;



[Serializable]
public class TiledLayer
{
    public int[] data;
    public int height;
    public int id;
    public string name;
    public int opacity;
    public string type;
    public bool visible;
    public int width;
    public int x;
    public int y;
}

[Serializable]
public class TiledMap
{
    public int width;
    public int height;
    public bool infinite;
    public TiledLayer[] layers;
    public int nextlayerid;
    public int nextobjectid;
    public string orientation;
}




public class TMapReader : MonoBehaviour
{

    //マップのCSV

    [SerializeField] public TextAsset _MapCsvFile;
    public TextAsset MapCsvFile
    {
        get => _MapCsvFile;
        set => _MapCsvFile = value;
    }

    //  jsonファイル
    [SerializeField] public TextAsset _MapJsonFile;
    public TextAsset MapJsonFile
    {
        get => _MapJsonFile;
        set => _MapJsonFile = value;
    }


    //  マップチップ
    [SerializeField] public TextAsset _MapChipGphFile;
    public TextAsset MapChipGphFile
    {
        get => MapChipGphFile;
        set => MapChipGphFile = value;
    }

    public List<List<int>> _CsvMapData;
    public TiledMap _TiledMap;
    public Image _TiledMapChipImage;





    void JsonRead()
    {
        _TiledMap = JsonUtility.FromJson<TiledMap>(MapJsonFile.text);
    }

    void CSVRead()
    {
        _CsvMapData = new List<List<int>>();
        //  リーダーの作成
        StringReader reader = new StringReader(MapCsvFile.text);

        List<string[]> csv_datas = new List<string[]>();
        while (reader.Peek() != -1)
        {
            //  一行づづ読み込ませる
            string line = reader.ReadLine();
            //  ,の区切りで文字列を保存
            csv_datas.Add(line.Split(','));
        }

        //  文字列の数値から普通の数値へパーサー
        for (int y = 0; y < csv_datas.Count(); ++y)
        {
            List<int> wk = new List<int>();
            for (int x = 0; x < csv_datas[y].Count(); ++x)
            {
                int num = int.Parse(csv_datas[y][x]);
                wk.Add(num);
            }
            _CsvMapData.Add(wk);
        }

    }

    //  マップチップのイメージロード
    void loadImage()
    {
    }
       


    // Start is called before the first frame update
    void Start()
    {
        CSVRead();
        JsonRead();
        loadImage();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
