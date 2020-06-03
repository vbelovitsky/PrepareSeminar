using System;

namespace Task_2_Lib
{
	public class LimitedSimbolChain : SimbolChain
	{
		int _start = char.MinValue;
		public int StartCode
		{
			set
			{
				if (value > _end) throw new ArgumentException("Значение левой границы не может быть больше правой");
				_start = value;
			}

			get
			{
				return _start;
			}
		}

		int _end = char.MaxValue;
		public int EndCode
		{
			set
			{
				if (value < _start) throw new ArgumentException("Значение правой границы не может быть меньше левой");
				_end = value;
			}

			get
			{
				return _end;
			}
		}

		public string Name { get; set; } = "Default chain";

		public LimitedSimbolChain() { }

		public LimitedSimbolChain(int start, int end, string name = "Default chain")
		{
			StartCode = start;
			EndCode = end;
			Name = name;
		}

		public override void AddToChain(char newSimb)
		{
			if (newSimb < StartCode || newSimb > EndCode)
			{
				throw new ArgumentOutOfRangeException($"Значение добавляемого символа ({(int)newSimb}) не входит в заданный диапазон [{StartCode}, {EndCode}]");
			}
			else
			{
				chain.Add(newSimb);
			}
		}

		public override string ToString()
		{
			return $"{Name}:  {string.Join("", chain)}";
		}
	}
}
