using System;

namespace RexyQue.Statistics.ApproximateStringMatching
{
    /// <summary>
    /// A group of methods for dealing with Jaro-Winkler similarity between two strings.
    /// </summary>
    public static class JaroWinkler
    {
        /// <summary>
        /// Calculates the Jaro-Winkler similarity between <paramref name="s1"/>
        /// and <paramref name="s2"/>.
        /// </summary>
        /// <param name="scalingFactor">
        /// The scaling factor for the prefix. Any value less than or equal to 0 will
        /// result in just the Jaro similarity. Any value about 0.25 will be reduced to
        /// 0.25. Default is 0.1.
        /// </param>
        /// <returns>
        /// The Jaro-Winkler similarity between <paramref name="s1"/> and <paramref name="s2"/>
        /// using <paramref name="scalingFactor"/> as the prefix scaling factor.
        /// </returns>
        public static double GetSimilarity(char[] s1, char[] s2, double scalingFactor = 0.1)
        {
            if (s1 is null)
            {
                throw new ArgumentNullException(nameof(s1));
            }
            if (s2 is null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            if (s1.Equals(s2))
            {
                return 1;
            }

            char[] min, max;
            if (s1.Length >= s2.Length)
            {
                max = s1;
                min = s2;
            }
            else
            {
                max = s2;
                min = s1;
            }

            if (min.Length == 0)
            {
                return 0;
            }

            int dist = (max.Length / 2) - 1;

            bool[] minMatched = new bool[min.Length];
            bool[] maxMatched = new bool[max.Length];

            double matches = 0;
            double transpositions = 0;

            for (int i = 0; i < min.Length; i++)
            {
                int start = Math.Max(0, i - dist);
                int end = Math.Min(i + dist + 1, max.Length);

                for (int j = start; j < end; j++)
                {
                    if (maxMatched[j] || min[i] != max[j])
                    {
                        continue;
                    }
                    minMatched[i] = true;
                    maxMatched[j] = true;
                    matches++;
                    break;
                }
            }

            if (matches == 0)
            {
                return 0;
            }

            int k = 0;
            for (int i = 0; i < min.Length; i++)
            {
                if (!minMatched[i])
                {
                    continue;
                }

                while (!maxMatched[k])
                {
                    k++;
                }

                if (min[i] != max[k])
                {
                    transpositions++;
                }

                k++;
            }

            double jaro = ((matches / s1.Length) +
                (matches / s2.Length) +
                ((matches - (transpositions / 2.0)) / matches)) / 3.0;

            if (scalingFactor <= 0)
            {
                return jaro;
            }

            int prefix = 0;
            int prefLen = Math.Min(4, min.Length);
            for (int i = 0; i < prefLen; i++)
            {
                if (s1[i] == s2[i])
                {
                    prefix++;
                }
                else
                {
                    break;
                }
            }

            return prefix > 0
                ? jaro + (Math.Min(scalingFactor, 0.25) * prefix * (1 - jaro))
                : jaro;
        }

        public static double GetDifference(char[] s1, char[] s2, double scalingFactor = 0.1)
        {
            return 1 - GetSimilarity(s1, s2, scalingFactor);
        }
    }
}
