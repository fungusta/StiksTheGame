using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//nid to change the system

public static class SaveSystem 
{
    public static void SavePlayer (PlayerHealth player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        //where to save the file
        //will consistently save in the same folder
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player); //run player data class

        //insert into file
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }
}
