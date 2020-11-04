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
            var textFromJson = File.ReadAllText(unpackedFilePath);
            var info = JsonUtility.FromJson<PlayerInfo>(textFromJson);

            player.GetComponent<BaseCharacterController>().ApplyNewInfo(info);
        }
    }
}
