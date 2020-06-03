using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Lib
{
    public abstract class SimbolChain
    {
		protected List<char> chain;

		protected SimbolChain()
		{
			chain = new List<char>();
		}

		public int GetChainLength
		{
			get
			{
				return chain.Count;
			}
		}

		public abstract void AddToChain(char newSimb);
    }
}
