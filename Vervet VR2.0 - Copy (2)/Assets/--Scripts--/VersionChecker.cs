using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class VersionChecker : MonoBehaviour
{
    public string versionNumber;
    public string githubRawTextUrl;
    public string sceneToLoad;

    private void Start()
    {
        string githubRawText = new WebClient().DownloadString(githubRawTextUrl);

        if (versionNumber != githubRawText.Trim())
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
