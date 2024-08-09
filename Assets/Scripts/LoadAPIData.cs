using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAPIData : MonoBehaviour, ILoadData
{
    [System.Serializable]
    public class URIData
    {
        public string URL;
    }

    private string _serverURL = "...";
    private string _gameURL = string.Empty;
    public string GetURI()
    {
        StartCoroutine(MakeRequest());
        return _gameURL;
    }

    IEnumerator MakeRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(_serverURL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                URIData data = JsonUtility.FromJson<URIData>(json);
                _gameURL =  data.URL;
            }
        }
    }
}
