using System;
using System.Collections.Generic;
using UnityEngine;

public class MapReader : MonoBehaviour
{
    public  void GetData(TextAsset mapToRead, out TileType[][] test, out UnitType[][] test2 )
    {
        string[] Signlist = mapToRead.text.Split('#');
        test = GetMapData(Signlist[0].Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries));
        test2 = GetWaveData(Signlist[1].Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries));
       // return (GetMapData(Signlist[0].Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries)),
       //        GetWaveData(Signlist[1].Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries)));
    }
    TileType[][] GetMapData(string[] rowList)
    {       
        TileType[][] MapData = new TileType[rowList.Length][];
        for (int x = 0; x < rowList.Length; x++)
        {
            MapData[x] = new TileType[rowList[x].Length];
            for (int y = 0; y < rowList[x].Length - 1; y++)
            {
                MapData[x][y] = TileMethods.TypeById[(int)char.GetNumericValue(rowList[x][y])];
            }
        }
        return MapData;
    }

    UnitType[][] GetWaveData(string[] waveList)
    {
        UnitType[][] cachedWaveData = new UnitType[waveList.Length][];
        for (int x = 1; x < waveList.Length; x++)
        {
            string[] wave = waveList[x].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            int nrOfUnits = 0;                    
            for (int i = 0; i < wave.Length; i++)
            {
                int temp;
                if (!int.TryParse(wave[i], out temp)) Debug.Log("Parse Error: " + x + " : " + i);
                nrOfUnits += temp;
            }
            cachedWaveData[x - 1] = new UnitType[nrOfUnits];
            for (int y = 0; y < wave.Length; y++)
            {
                for (int z = 0; z < nrOfUnits; z++)
                {
                    cachedWaveData[x - 1][z] = UnitMethods.TypeById[y];
                }
            }   
        }    
        return cachedWaveData;
    }



    //void ReadTextAsset(TextAsset file)
    //{
    //    string[] Signlist = file.text.Split('#');
    //    string[] rowList = Signlist[0].Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
    //    cachedMapData = new TileType[rowList.Length][];
    //    for (int x = 0; x < rowList.Length; x++)
    //    {
    //        cachedMapData[x] = new TileType[rowList[x].Length];
    //        for (int y = 0; y < rowList[x].Length-1; y++)
    //        {
    //            cachedMapData[x][y] = TileMethods.TypeById[(int)char.GetNumericValue(rowList[x][y])];
    //        }
    //    }

    //    string[] waveList = Signlist[1].Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
    //    cachedWaveData = new int[waveList.Length][];     
    //    for (int x = 1; x < waveList.Length; x++)
    //    {
    //        string []wave = waveList[x].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
    //        cachedWaveData[x - 1] = new int[wave.Length];
    //        for (int y = 0; y < wave.Length; y++)
    //        {
    //            if (!int.TryParse(wave[y], out cachedWaveData[x - 1][y])) Debug.Log("Parse Error: " + x + " : " + y);
    //        }
    //    }
        
    //}
}



            
 
