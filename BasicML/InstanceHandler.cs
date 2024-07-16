using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class InstanceHandler
	{
		private static List<Cpu> instances = new();

		public static void AddInstance() { instances.Add(new()); }

		public static Cpu GetCpu(int instanceIndex) { return instances[instanceIndex]; }
	}
}
