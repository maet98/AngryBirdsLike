using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class MapManager : MonoBehaviour
{
    public GameObject Derecha, Izquierda, Cerdo, Horizontal;
    Dictionary<char, GameObject> celdasPrefabs;
    XmlDocument level1;


    void Start()
    {
        celdasPrefabs = new Dictionary<char, GameObject>
        {
            { 'D',Derecha },
            { 'E',Cerdo },
            { 'I',Izquierda },
            { 'H',Horizontal }
        };
        level1 = new XmlDocument();
        level1.LoadXml(Resources.Load<TextAsset>("Nivel"+GameManager.level).text);
        LoadMap();
    }
    private void LoadMap()
    {
        GameObject _NewCell;
        int i, j;
        i = 8;
        char anterior = ' ';
        foreach (XmlNode filaActual in level1.SelectNodes("//Level/Map/Row"))
        {
            i--;
            j = 10;
            foreach (char celdaActual in filaActual.InnerText)
            {
                j++;
                if(celdaActual!= 'A')
                {
                    Vector3 pos = celdasPrefabs[celdaActual].transform.position;
                    if(anterior == 'I' && celdaActual == 'D')
                    {
                        j--;
                    }
                    var obj = Instantiate(celdasPrefabs[celdaActual], new Vector3(j+pos.x, i+pos.y), celdasPrefabs[celdaActual].transform.rotation);
                    if(celdaActual == 'E')
                    {
                        Debug.Log(obj.transform.position);
                    }
                }
                anterior = celdaActual;
            }
        }
        
    }
}
