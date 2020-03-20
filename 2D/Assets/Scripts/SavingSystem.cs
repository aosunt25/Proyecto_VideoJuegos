using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingSystem
{
    public static void SavePlayer(GameMaster juego)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.noteToMySelf";
        FileStream stream = new FileStream(path, FileMode.Create);

        InformacionDeJugar data = new InformacionDeJugar(juego);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static InformacionDeJugar CargarJugador()
    {
        string path = Application.persistentDataPath + "/player.noteToMySelf";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InformacionDeJugar data = formatter.Deserialize(stream) as InformacionDeJugar;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Documento no Encontrado");
            return null;
        }
    }

    public static void DeleteFile()
    {
        string path = Application.persistentDataPath + "/player.noteToMySelf";
        File.Delete(path);
    }
}
