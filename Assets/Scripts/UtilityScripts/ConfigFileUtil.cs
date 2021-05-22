using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Dynamic;

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
            var converter = new ExpandoObjectConverter(); 

            //return JObject.Parse(GetJsonString(filename));
            return JsonConvert.DeserializeObject<ExpandoObject>(GetJsonString(filename), converter);
            //return JsonConvert.DeserializeObject(GetJsonString(filename));
        }

        public static dynamic GetValue(string key)
        {
            dynamic json = GetDynamicJson(playConfigPath);
            //Debug.Log(json);
            foreach (KeyValuePair<string, object> kvp in json)
            {
                if (kvp.Key == key)
                {
                    return kvp.Value;
                }
            }
            return null;
        }

        public static void UpdateFile(object key, object value)
        {
            //dynamic json = GetDynamicJson(playConfigPath);
            //json[key].Value = value;
            //File.WriteAllText(playConfigPath, JsonConvert.SerializeObject(json));
        }

    }
}
