using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    public class Worker
    {
        public Thread Thread;
        public int[] Accumulator = new int[256];
        public int Start, End;
        public MethodInfo[] Data;

        public Worker(int start, int end, MethodInfo[] buf)
        {
            this.Start = start;
            this.End = end;
            this.Data = buf;

            this.Thread = new Thread(Func);
            this.Thread.Start();
        }
        public void Func()
        {
            for (int i = Start; i < End; i++)
                RuntimeHelpers.PrepareMethod(Data[i].MethodHandle);
        }
    }
}
