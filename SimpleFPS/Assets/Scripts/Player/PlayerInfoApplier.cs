using System;
using System.IO;
using System.IO.Compression;
using Tools;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class PlayerInfoApplier : MonoBehaviour
    {
        private const string URL = @"https://dminsky.com/settings.zip";
        private const string FILENAME = "settings.zip";
        private const string OUTPUT_PATH = "PlayerInfoUnpacked";
        private const string UNPACKED_FILENAME = "settings.json";

        [MenuItem("Player/Apply player info from server")]
        private static void Apply()
        {
            var player = GameObject.Find("MainCharacter");

            var downloadPath = Path.Combine(Application.persistentDataPath, FILENAME);
            FileManager.DownloadAndExtract(URL, downloadPath, OUTPUT_PATH);

            var unpackedFilePath = Path.Combine(OUTPUT_PATH, UNPACKED_FILENAME);
            var info = ReadPlayerInfo(unpackedFilePath);

            player.GetComponent<BaseCharacterController>().ApplyNewInfo(info);
        }

        private static PlayerInfo ReadPlayerInfo(string path)
        {
            try
            {
                var textFromJson = File.ReadAllText(path);
                var info = JsonUtility.FromJson<PlayerInfo>(textFromJson);

                return info;
            }
            catch (FileNotFoundException e)
            {
                Debug.Log($"File not found: {e.FileName}");
                throw;
            }
            catch (IOException e)
            {
                Debug.Log($"File could not be read: {e.Source}");
                throw;
            }
        }
    }
}
