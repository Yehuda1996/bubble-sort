using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bubble_sort
{
	internal class Linked_List
	{
		interface ListR<T>
		{
			T? Get(int index);
			void Set(int index, T value);
			T? RemoveAt(int index);
			R? Aggregate<R>(R init, Func<R, T, R> reducer);
			// insert to the end of the list
			void Push(T item);
			// removes from the end of the list
			T? Pop();
			// insert to the the begining of the list
			void Unshift(T item);
			//  removes from the begining of the list
			T? Shift();
			// returns the length
			int Count();
			void Reverse();
		}
		internal class Node<T>
		{
			public T Value { get; set; }
			public Node<T>? Next { get; set; }
		}
		internal class LinkedListE<T> : ListR<T>
		{
			private Node<T>? _head;
			private Node<T>? _tail;
			private int _length = 0;
			public int Count() => _length;
			public T? Pop()
			{
				if (_length == 0) return default;
				if (_length == 1)
				{
					_length = 0;
					T value = _head.Value;
					_head = _tail = null;
					return value;
				}
				var temp = _head;
				var pre = _head;
				while (temp.Next != null)
				{
					pre = temp;
					temp = temp.Next;
				}
				pre.Next = null;
				_tail = pre;
				_length--;
				return temp.Value;
			}
			public void Push(T item)
			{
				Node<T> newNode = new() { Value = item };
				if (_length == 0)
				{
					_head = newNode;
					_tail = newNode;
					_length++;
					return;
				}
				_tail.Next = newNode;
				_tail = newNode;
				_length++;
			}
			public T? Shift()
			{
				// case no items
				if (_length == 0) { return default; }
				T item = _head.Value;
				// case 1 item
				if (_length == 1)
				{
					_head = null;
					_tail = null;
					_length--;
					return item;
				}
				// rest...
				_head = _head.Next;
				_length--;
				return item;
			}
			public void Unshift(T item)
			{
				Node<T> newNode = new() { Value = item };
				newNode.Next = _head;
				if (_length == 0) { _tail = newNode; }
				_length++;
				_head = newNode;
			}
			public override string ToString()
			{
				if (_length == 0) return "[]";
				string repr = "[";
				var temp = _head!;
				repr += $"{temp.Value}";
				while (temp.Next != null)
				{
					repr += $", {temp.Next.Value}";
					temp = temp.Next;
				}
				return $"{repr}]";
			}

			public void Reverse()
			{
				if (_length <= 1) { return; }
				var temp = _head!;
				_head = _tail;
				_tail = temp;
				var next = temp.Next;
				Node<T>? prev = null;
				for (int i = 0; i < _length; i++)
				{
					next = temp.Next;
					temp.Next = prev;
					prev = temp;
					temp = next;
				}
				_tail.Next = null;
			}

			public T? Get(int index)
			{
				if (index < 0 || index >= _length) { return default; }

				var temp = _head;
				for (int i = 0; i < index; i++)
				{
					if (i == index)
					{
						return temp.Value;
					}
					temp = temp.Next;
				}
				return default;
			}

			public void Set(int index, T value)
			{
				int counter = 0;
				while (counter < _length)
				{
					_head = _head.Next;
					counter++;
					if (counter == index)
					{
						_head.Value = value;
					}
				}
			}

			public T? RemoveAt(int index)
			{
				int counter = 0;
				while (counter < _length)
				{
					_head = _head.Next;
					counter++;
					if (counter == index)
					{
						return default;
					}
				}
				return default;
			}

			public R? Aggregate<R>(R init, Func<R, T, R> reducer)
			{
				throw new NotImplementedException();
			}
		}
	}
}
