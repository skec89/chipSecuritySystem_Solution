using System;
using System.Collections.Generic;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ColorChip> chips = new List<ColorChip>
            {
            new ColorChip(Color.Blue, Color.Yellow),
            new ColorChip(Color.Red, Color.Orange),
            new ColorChip(Color.Orange, Color.Purple),
            new ColorChip(Color.Green, Color.Purple),
            new ColorChip(Color.Purple, Color.Green),
            new ColorChip(Color.Yellow, Color.Red)
            };

            List<ColorChip> solution = FindValidSequence(chips);

            if (solution != null)
            {
                solution.RemoveAt(0);
                Console.WriteLine("Valid sequence found:");
                Console.WriteLine(string.Join(" ", solution));
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
        }

        public static List<ColorChip> FindValidSequence(List<ColorChip> chips)
        {
            List<ColorChip> sequence = new List<ColorChip>();
            HashSet<int> usedIndexes = new HashSet<int>();
            sequence.Add(new ColorChip(Color.Blue, Color.Blue));

            if (FindSequence(chips, sequence, usedIndexes))
            {
                return sequence;
            }

            return null;
        }

        private static bool FindSequence(List<ColorChip> chips, List<ColorChip> sequence, HashSet<int> usedIndexes)
        {
            if (sequence.Count > 1 && sequence[sequence.Count - 1].EndColor == Color.Green)
            {
                return true;
            }

            for (int i = 0; i < chips.Count; i++)
            {
                if (!usedIndexes.Contains(i) && chips[i].StartColor == sequence[sequence.Count - 1].EndColor)
                {
                    sequence.Add(chips[i]);
                    usedIndexes.Add(i);

                    if (FindSequence(chips, sequence, usedIndexes))
                    {
                        return true;
                    }

                    sequence.Remove(chips[i]);
                    usedIndexes.Remove(i);
                }
            }

            return false;
        }
    }
}
