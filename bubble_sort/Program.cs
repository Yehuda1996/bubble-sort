using System.Security.Cryptography.X509Certificates;

namespace bubble_sort
{
	internal class Program
	{
		public int[]  bubble_sort(int[] a)
		{
			for (int i = 0; i < a.Length; i++)
			{
				for (int j = 0; j < a.Length; j++)
				{
					if (a[i] > a[j])
					{
						int temp = a[i];
						a[i] = a[j];
						a[j] = temp;
					}
				}
			}
			return a;
		}

		public int[] selection_sort(int[] a)
		{
			int length = a.Length;
			for (int i = 0; i < length; i++)
			{
				int min_index = find_min_index(a, i);
				a = swap(a, i, min_index);	
			}
			return a;
		}

		public int find_min_index(int[] a, int i)
		{
			int min_index = i;
			for (int j = i; j < a.Length; j++)
			{
				if (a [j] < a[min_index])
				{
					min_index = j;
				}
			}
			return min_index;
		}

		public int[] swap(int[] a, int i, int j)
		{
			int temp = a [i];
			a [i] = a [j];
			a [j] = temp;
			return a;
		}	
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}
	}
}
