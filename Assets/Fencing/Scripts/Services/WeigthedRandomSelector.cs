using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Fencing.Scripts.Services
{
    internal class WeigthedRandomSelector<T>
    {
        private SortedList<int, T> weightedItems = new SortedList<int, T>();
        private int totalWeight = 0;

        public WeigthedRandomSelector<T> Add(int weight, T item)
        {
            if (weight > 0)
            {
                totalWeight += weight;
                weightedItems.Add(totalWeight, item);
            }

            return this;
        }

        public T GetRandom()
        {
            int random = Random.Range(1, totalWeight);
            return weightedItems.First(item => item.Key >= random).Value;
        }
    }
}