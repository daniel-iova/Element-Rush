using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UnityEngine;

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
            foreach (KeyValuePair<string, object> kvp in json)
            {
                if (kvp.Key == key)
                {
                    return kvp.Value;
                }
            }
            return null;
        }

        public static void UpdateMode(object value)
        {
            dynamic json = JObject.Parse(GetJsonString(playConfigPath));
            json["mode"].Value = value;
            File.WriteAllText(playConfigPath, JsonConvert.SerializeObject(json));
        }

    }
}
