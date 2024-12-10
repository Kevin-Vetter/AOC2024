#if !DEBUG
#region DAY 1
//DAY 1:1
string[] input = File.ReadAllLines("Inputs/Day1.tsv");
List<int> left = new();
List<int> right = new();
int res = 0;


foreach (string line in input)
{
    left.Add(Convert.ToInt32(line.Remove(5)));
    left.Sort();
    right.Add(Convert.ToInt32(line.Substring(8)));
    right.Sort();
}

for (int i = 0; i < left.Count; i++)
{
    res += Math.Abs(left[i] - right[i]);
}

Console.WriteLine(res);

//DAY 1:2
for (int i = 0; i < left.Count; i++)
{
    int j = 0;
    foreach (int num in right)
    {
        if (left[i] == num)
        {
            j++;
        }
    }
    left[i] *= j;
}

Console.WriteLine(left.Sum());
#endregion
#endif
#region DAY 2
// DAY 2:1

string[] input = File.ReadAllLines("Inputs/Day2.txt");
List<string[]> strings = new();
int res = 0;

foreach (string line in input)
{
    strings.Add(line.Split(' '));
}

foreach (string[] numbs in strings)
{
    int[] ints = Array.ConvertAll(numbs, s => int.Parse(s));
    int[] intsSorted = Array.ConvertAll(numbs, s => int.Parse(s));
    int[] intsSortedRev = Array.ConvertAll(numbs, s => int.Parse(s));

    Array.Sort(intsSorted);
    Array.Sort(intsSortedRev);
    Array.Reverse(intsSortedRev);

    if (Enumerable.SequenceEqual(ints, intsSorted) || Enumerable.SequenceEqual(ints, intsSortedRev))
    {
        int prev = -1;
        bool safe = true;
        foreach (var i in ints)
        {
            if (prev != -1 && safe)
            {
                int diff = Math.Abs(prev - i);
                if (diff <= 3 && diff > 0)
                {
                    safe = true;
                }
                else
                {
                    safe = false;
                }
            }
            prev = i;
        }
        if (safe)
        {
            res++;
        }
    }
}


Console.WriteLine(res);

// DAY 2:2
int prevres = -1;
res = 0;
foreach (string[] numbs in strings)
{
    int[] ints = Array.ConvertAll(numbs, s => int.Parse(s));
    int[] intsSorted = Array.ConvertAll(numbs, s => int.Parse(s));
    int[] intsSortedRev = Array.ConvertAll(numbs, s => int.Parse(s));

    Array.Sort(intsSorted);
    Array.Sort(intsSortedRev);
    Array.Reverse(intsSortedRev);

    if (Enumerable.SequenceEqual(ints, intsSorted) || Enumerable.SequenceEqual(ints, intsSortedRev))
    {
        int prev = -1;
        bool safe = true;
        if (res != prevres)
        {
            prevres = res;

            for (int j = 0; j < ints.Length; j++)
            {
                int[] x = new int[ints.Length];
                Array.Copy(ints, x, ints.Length);
                List<int> y = x.ToList();

                foreach (var i in x)
                {
                    if (prev != -1 && safe)
                    {
                        int diff = Math.Abs(prev - i);
                        if (diff <= 3 && diff > 0)
                        {
                            safe = true;
                        }
                        else
                        {
                            safe = false;
                        }
                    }
                    prev = i;
                }
                if (safe)
                {
                    res++;
                }
                else
                {
                    y.RemoveAt(j);
                }
            }
        }

    }

}
Console.WriteLine(res);
#endregion