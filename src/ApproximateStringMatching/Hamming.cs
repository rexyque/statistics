using System;

namespace RexyQue.Statistics.ApproximateStringMatching
{
    /// <summary>
    /// A group of methods for dealing with Hamming distances between two strings.
    /// </summary>
    public static class Hamming
    {
        /// <summary>
        /// Calculates the Hamming distance between <paramref name="s1"/> and <paramref name="s2"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the length of <paramref name="s1"/> and <paramref name="s2"/>
        /// are not the same.
        /// </exception>
        /// <returns>
        /// The Hamming distance between <paramref name="s1"/> and <paramref name="s2"/>.
        /// </returns>
        public static int GetDistance(char[] s1, char[] s2)
        {
            if (s1.Length != s2.Length)
            {
                throw new InvalidOperationException("Cannot calculate Hamming distance for strings of different lengths");
            }
            int result = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// Calculates the Hamming similarity (length - Hamming distance) between 
        /// <paramref name="s1"/> and <paramref name="s2"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the length of <paramref name="s1"/> and <paramref name="s2"/>
        /// are not the same.
        /// </exception>
        /// <returns>
        /// The Hamming similarity between <paramref name="s1"/> and <paramref name="s2"/>.
        /// </returns>
        public static int GetSimilarity(char[] s1, char[] s2)
        {
            return s1.Length - GetDistance(s1, s2);
        }
    }
}
