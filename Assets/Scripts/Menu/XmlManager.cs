using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;
using Assets;

public class XmlManager : MonoBehaviour
{
    public static Game currentGame;
    public static Configuracion configuracion;
    public static HighScore highScore;
    string rutaXML;
    string rutaconfXML;
    string rutaHighXML;
    string filename = "lastGameState.xml";
    string fileConf = "conf.xml";
    string fileHighScore = "highscore.xml";
    private void Awake()
    {
        rutaXML = getPath(filename);
        rutaconfXML = getPath(fileConf);
        rutaHighXML = getPath(fileHighScore);
        LoadHighScores();
        LoadConfiguraciones();
    }
    private void Start()
    {
        var cant = GameObject.FindGameObjectsWithTag("manager");
        if (cant.Length > 1) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
        currentGame = new Game();
        
    }

    public void SaveState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));

        using (FileStream filestream = new FileStream(rutaXML, FileMode.Create))
        {
            dcSerializer.WriteObject(filestream, currentGame);
        }
    }
    public void SaveHighScore()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(HighScore));

        using (FileStream filestream = new FileStream(rutaHighXML, FileMode.Create))
        {
            dcSerializer.WriteObject(filestream, highScore);
        }
    }

    public void SaveConfiguraciones()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Configuracion));
        using (FileStream filestream = new FileStream(rutaconfXML, FileMode.Create))
        {
            dcSerializer.WriteObject(filestream, configuracion);
        }
    }

    public void LoadConfiguraciones()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Configuracion));
        if (File.Exists(rutaconfXML))
        {
            using (FileStream filestream = new FileStream(rutaconfXML, FileMode.Open))
            {
                configuracion = (Configuracion)dcSerializer.ReadObject(filestream);
            }
        }
        else
        {
            configuracion = new Configuracion();
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
    public void LoadHighScores()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(HighScore));
        if (File.Exists(rutaHighXML))
        {
            using (FileStream filestream = new FileStream(rutaHighXML, FileMode.Open))
            {
                highScore = (HighScore)dcSerializer.ReadObject(filestream);
            }
        }
        else
        {
            highScore = new HighScore();
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

