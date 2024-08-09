using UnityEngine;

namespace Assets.Scripts
{
    public class LoadJsonData : MonoBehaviour, ILoadData
    {
        [System.Serializable]
        public class URIData
        {
            public string URL; 
        }

        public string GetURI()
        {
            string url = string.Empty;
            TextAsset jsonFile = Resources.Load<TextAsset>("GameUrl");

            if (jsonFile != null)
            {
                URIData data = JsonUtility.FromJson<URIData>(jsonFile.text);

                Debug.Log("Loaded URL: " + data.URL);
                url = data.URL;
            }
            else
            {
                Debug.LogError("File not found in Resources folder");
            }

            return url;
        }
    }
}
