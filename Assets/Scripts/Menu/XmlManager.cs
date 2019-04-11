using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;


public class XmlManager : MonoBehaviour
{
    public static Game currentGame;
    string rutaXML;
    string rutaconfXML;
    string filename = "lastGameState.xml";
    string fileConf = "conf.xml";
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        rutaXML = getPath(filename);
        rutaconfXML = getPath(fileConf);
        currentGame = new Game();
        LoadConfiguraciones();
    }


    public void SaveState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));

        using (FileStream filestream = new FileStream(rutaXML, FileMode.Create))
        {
            dcSerializer.WriteObject(filestream, currentGame);
        }
    }

    public void SaveConfiguraciones()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Configuracion));
        using (FileStream filestream = new FileStream(rutaconfXML, FileMode.Create))
        {
            Configuracion conf = GetComponent<Configuracion>();
            dcSerializer.WriteObject(filestream, conf);
        }
    }

    public void LoadConfiguraciones()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Configuracion));
        if (File.Exists(rutaconfXML))
        {
            using (FileStream filestream = new FileStream(rutaconfXML, FileMode.Open))
            {
                Configuracion conf = (Configuracion)dcSerializer.ReadObject(filestream);
                GetComponent<Configuracion>().Music = conf.Music;
                GetComponent<Configuracion>().Sonido = conf.Sonido;
                GetComponent<Configuracion>().nombre = conf.nombre;
            }
        }
        

    }

    public void LoadState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));
        if (File.Exists(rutaXML))
        {
            using (FileStream filestream = new FileStream(rutaXML, FileMode.Open))
            {
                currentGame = (Game)dcSerializer.ReadObject(filestream);
            }
        }
        else
        {
            currentGame = new Game();
        }

    }

    //dependiendo donde se esta corriendo dara el path que se necesita
    private string getPath(string filename)
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Resources/" + filename;
#elif UNITY_ANDROID
                return Application.persistentDataPath+filename;
#elif UNITY_IPHONE
                return Application.persistentDataPath+"/"+filename;
#else
                return Application.dataPath +"/"+ filename;
#endif
    }
}

