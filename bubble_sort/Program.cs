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
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}
	}
}
