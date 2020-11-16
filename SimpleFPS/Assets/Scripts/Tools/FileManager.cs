using System;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;

namespace Tools
{
    public class FileManager
    {
        public static void DownloadAndExtract(string url, string path, string outputPath)
        {
            var request = UnityWebRequest.Get(url);
            request.downloadHandler = new DownloadHandlerFile(path);

            var downloadOperation = request.SendWebRequest();
            downloadOperation.completed += (result) =>
            {
                if (request.isHttpError || request.isNetworkError)
                {
                    Debug.Log($"Error occured while downloading: {request.error}");
                }
                else
                {
                    ExtractToDirectory(path, outputPath);
                }
            };
        }

        private static void ExtractToDirectory(string path, string outputPath)
        {
            try
            {
                Directory.CreateDirectory(outputPath);

                ZipFile.ExtractToDirectory(path, outputPath);
            }
            catch (DirectoryNotFoundException e)
            {
                Debug.Log("The specified path is invalid.");
            }
            catch (IOException)
            {
                Debug.Log("Could not extract archive: probably it already have been unpacked.");
            }
            catch (Exception)
            {
                Debug.Log("Could not extract archive.");
            }
        }
    }
}
