using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI
{
    public class GamePoinsManager
    {

        private const string POINS_SAVE_KEY = "poins_save_key";

        public static event EventHandler<int> OnUpdatedPoins;

        public static void AddPoins(int addValue = 1)
        {
            int poins = GetCurrentCountPoins();
            poins += addValue;
            SetPoins(poins);
        }

        public static void SetPoins(int poins)
        {
            SavePoins(poins);
            OnUpdatedPoins?.Invoke(typeof(GamePoinsManager), poins);
        }
        private static void SavePoins(int poins)
        {
            GameDataManager.Save(POINS_SAVE_KEY, poins);
        }
        public static int GetCurrentCountPoins()
        {
            int result = 0;
            GameDataManager.Load<int>(POINS_SAVE_KEY, x => result = x);
            Debug.Log(result);
            return result;
        }
    }
}