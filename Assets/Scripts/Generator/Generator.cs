using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Generator
{
    public class Generator
    {
        private int width;
        private int height;        
        private Random rand = new Random();
        private int count => width * height;

        public Generator(int width, int height) 
        {
            this.width = width;
            this.height = height;
        }


        /// <summary>
        /// The function generates letters by id.
        /// </summary>
        /// <returns>Returns a dictionary of letters.</returns>
        public Dictionary<int, char> GenerateLetters() 
        {
            Dictionary<int, char> letters = new Dictionary<int, char>();
            for(int i = 1; i <= count; ++i)
            {
                letters.Add(i, GetRandChar());
            }
            return letters;
        }

        /// <summary>
        /// The method generates id pairs from letters.
        /// </summary>
        /// <returns>Returns a dictionary of letters id.</returns>
        public Dictionary<int, int> GetSwapLetterPairs() 
        {
            List<int> mixedList = GetMixedList();
            Dictionary<int, int> swapLetters = new Dictionary<int, int>();
            for(int i = 0, c = mixedList.Count - 1; i < (mixedList.Count-1) / 2; ++i, --c)
            {
                swapLetters.Add(mixedList[i], mixedList[c]);
            }
            return swapLetters;
        }

        private char GetRandChar() => (char)rand.Next('A', 'Z' + 1);

       

        private List<int> GetMixedList() 
        {
            List<int> mixedList = new List<int>();
            for(int i = 1; i <= count; ++i)
            {
                mixedList.Add(i);
            }
            for(int i = 0; i < mixedList.Count; ++i)
            {
                var randomId = rand.Next(0, mixedList.Count);
                int temp = mixedList[i];
                mixedList[i] = mixedList[randomId];
                mixedList[randomId] = temp;
            }
            return mixedList;
        }

    }
}
