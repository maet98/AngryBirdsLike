using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using Assets.Scripts;

public class MapManager : MonoBehaviour
{
    public GameObject Derecha, Izquierda, Cerdo, Horizontal;
    public GameObject aveRoja, AveVerde, hook;
    Dictionary<char, GameObject> celdasPrefabs;
    Dictionary<string, GameObject> characterPrefabs;
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
        characterPrefabs = new Dictionary<string, GameObject>
        {
            {"RedBird",aveRoja},
            { "GreenBird",AveVerde},
            { "Hook",hook}
        };
        level1 = new XmlDocument();
        level1.LoadXml(Resources.Load<TextAsset>("Nivel"+GameManager.level).text);
        LoadMap();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            guardar();
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            load();
        }
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
                    obj.name = celdaActual.ToString();
                }
                anterior = celdaActual;
            }
        }

        foreach (XmlNode item in level1.SelectNodes("//Level/Characters/Character"))
        {
            var obj = Instantiate(characterPrefabs[item.Attributes["PrefabName"].Value],
                new Vector3(float.Parse(item.Attributes["Posx"].Value), float.Parse(item.Attributes["Posy"].Value)), Quaternion.identity);
            obj.name = item.Attributes["PrefabName"].Value;
        }
    }

    public void guardar()
    {
        XmlManager.currentGame.Birds.Clear();
        foreach (var item in GameObject.FindGameObjectsWithTag("Bird"))
        {
            Character nuevo = new Character();
            nuevo.PrefabName = item.name;
            nuevo.rotation = item.transform.rotation;
            nuevo.posicion = item.transform.position;
            XmlManager.currentGame.Birds.Add(nuevo);
        }
        XmlManager.currentGame.Bricks.Clear();
        foreach (var item in GameObject.FindGameObjectsWithTag("Brick"))
        {
            Character nuevo = new Character();
            nuevo.PrefabName = item.name;
            nuevo.rotation = item.transform.rotation;
            nuevo.posicion = item.transform.position;
            XmlManager.currentGame.Bricks.Add(nuevo);
        }
        XmlManager.currentGame.Pigs.Clear();
        foreach (var item in GameObject.FindGameObjectsWithTag("Pig"))
        {
            Character nuevo = new Character();
            nuevo.PrefabName = item.name;
            nuevo.rotation = item.transform.rotation;
            nuevo.posicion = item.transform.position;
            XmlManager.currentGame.Bricks.Add(nuevo);
        }
        GameObject.Find("XmlManager").GetComponent<XmlManager>().SaveState();
        
    }

    public void load()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().destroyAll();
        GameObject.Find("XmlManager").GetComponent<XmlManager>().LoadState();
        foreach (var item in XmlManager.currentGame.Pigs)
        {
            var obj = Instantiate(celdasPrefabs[char.Parse(item.PrefabName)], item.posicion, item.rotation);
            obj.name = item.PrefabName;
        }
        foreach (var item in XmlManager.currentGame.Bricks)
        {
            var obj = Instantiate(celdasPrefabs[char.Parse(item.PrefabName)], item.posicion, item.rotation);
            obj.name = item.PrefabName;
        }
        foreach (var item in XmlManager.currentGame.Birds)
        {
            var obj = Instantiate(characterPrefabs[item.PrefabName], item.posicion, item.rotation);
            obj.name = item.PrefabName;
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().reload();
    }

    public void DestroyAll()
    {
        List<GameObject> gameObjects = new List<GameObject>();
        gameObjects.AddRange(GameObject.FindGameObjectsWithTag("Hook"));
        gameObjects.AddRange(GameObject.FindGameObjectsWithTag("Bird"));
        gameObjects.AddRange(GameObject.FindGameObjectsWithTag("Pig"));
        foreach (var item in gameObjects)
        {
            Destroy(item);
        }
    }
}
