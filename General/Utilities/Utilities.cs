using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace CatUtilities
{
    
    public static class Utilities 
    {
        //random thu tu mot list
        public static List<T> SortOrder<T>(List<T> list,int amount)
        {
            return list.OrderBy(d => System.Guid.NewGuid()).Take(amount).ToList();
        }

        //lay ket qua theo ty le xac suat
        public static bool Chance(int rand, int max = 100)
        {
            return UnityEngine.Random.Range(0,max) < rand;
        }

        //random gia enum trong mot kieu enum
        private static System.Random random = new System.Random();
        public static T RandomEnumValue<T>()
        {
            var v = System.Enum.GetValues(typeof(T));
            return (T)v.GetValue(random.Next(v.Length));
        }

        //random gia tri tu 1 list
        public static T RandomInMember<T>(params T[] ts) 
        {
            return ts[UnityEngine.Random.Range(0, ts.Length)];
        }

        public static T GetLastPositionFromList<T>(List<T> points)
        {
            if (points != null && points.Count > 0)
            {
                // Lấy phần tử cuối cùng trong danh sách
                return points[points.Count - 1];
            }
            else
            {
                // Trả về một giá trị mặc định nếu danh sách rỗng hoặc null
                return default(T);
            }
        }

        public static void SetLayer(GameObject obj, string layerName, bool includeChildren = false)
        {
            int layer = LayerMask.NameToLayer(layerName);
            if (layer == -1)
            {
                Debug.LogError($"Layer \"{layerName}\" does not exist.");
                return;
            }

            // Set the layer of the current GameObject
            obj.layer = layer;

            // Optionally set the layer of all children
            if (includeChildren)
            {
                foreach (Transform child in obj.transform)
                {
                    SetLayerRecursively(child.gameObject, layer);
                }
            }
        }

        private static void SetLayerRecursively(GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
            {
                SetLayerRecursively(child.gameObject, layer);
            }
        }

        public static void RandomizePositionInArray(Transform[] transformArray)
        {
            // Use Fisher-Yates shuffle algorithm to randomize book positions
            for (int i = transformArray.Length - 1; i > 0; i--)
            {
                int randomIndex = UnityEngine.Random.Range(0, i + 1);
                // Swap the positions of booksTransform[i] and booksTransform[randomIndex]
                Vector3 tempPosition = transformArray[i].position;
                transformArray[i].position = transformArray[randomIndex].position;
                transformArray[randomIndex].position = tempPosition;
            }
        }

        public static void ActiveOneObjectRandom(GameObject[] gameObjects)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }

            int randomIndex = UnityEngine.Random.Range(0, gameObjects.Length);
            gameObjects[randomIndex].SetActive(true);
            
        }


    }
}

