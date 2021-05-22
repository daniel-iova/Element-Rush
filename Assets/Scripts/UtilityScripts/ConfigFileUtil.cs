using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.UtilityScripts
{
    public class ConfigFileUtil : MonoBehaviour
    {
        private static string playConfigPath = Path.Combine("Assets", "Scripts", "UtilityScripts", "playconfig.json");
        private static string GetJsonString(string filename)
        {
            return File.ReadAllText(filename);
        }
        private static dynamic GetDynamicJson(string filename)
        {
            return JObject.Parse(GetJsonString(filename));
        }

        public static dynamic GetMode()
        {
            dynamic json = GetDynamicJson(playConfigPath);
            return json.mode;
        }
        //object x = JsonUtility.FromJson<object>("x");

        public static void UpdateFile(object key, object value)
        {
            dynamic json = GetDynamicJson(playConfigPath);
            json[key].Value = value;
            File.WriteAllText(playConfigPath, JsonConvert.SerializeObject(json));
        }

    }
}
