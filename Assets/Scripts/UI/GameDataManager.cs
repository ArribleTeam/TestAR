using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

namespace UI
{
    public static class GameDataManager
    {

        public static void Save<T>(string key, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(key, json);
        }
        public static void Load<T>(string key, Action<T> onHasResult, Action onResultNull = null)
        {
            T result;
            if (PlayerPrefs.HasKey(key) == true)
            {
                string jsonData = PlayerPrefs.GetString(key);
                result = JsonConvert.DeserializeObject<T>(jsonData);
                onHasResult.Invoke(result);
            }
            else
            {
                result = default;
                onResultNull?.Invoke();
            }
        }
    }
}