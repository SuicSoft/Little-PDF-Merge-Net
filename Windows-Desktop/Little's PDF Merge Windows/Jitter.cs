using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    public class Jitter
    {
        public static void PreJit(object instance)
        {
            PreJitMarkedMethods(instance.GetType());
        }


        public static void PreJitAll(object instance)
        {
            PreJitAllMethods(instance.GetType());
        }

        public static void BeginPreJitAll(object instance)
        {
            Thread preJitThread = new Thread(() =>
            {
                PreJitAllMethods(instance.GetType());
            });

            preJitThread.Name = "PreJittingThread";
            preJitThread.Priority = ThreadPriority.Lowest;
            preJitThread.Start();

        }

        public static void PreJit<T>() where T : class
        {
            PreJitMarkedMethods(typeof(T));
        }


        public static void PreJitAll<T>() where T : class
        {
            PreJitAllMethods(typeof(T));
        }

        public static void BeginPreJitAll<T>() where T : class
        {
            Thread preJitThread = new Thread(() =>
            {
                PreJitAllMethods(typeof(T));
            });

            preJitThread.Name = "PreJittingThread";
            preJitThread.Priority = ThreadPriority.Lowest;
            preJitThread.Start();
        }

        public static void PreJitAll(Assembly assembly)
        {
            var classes = assembly.GetTypes();
            foreach (var classType in classes)
            {
                PreJitAllMethods(classType);
            }
        }

        public static void BeginPreJitAll(Assembly assembly)
        {
            Thread preJitThread = new Thread(() =>
            {
                PreJitAll(assembly);
            });

            preJitThread.Name = "PreJittingThread";
            preJitThread.Priority = ThreadPriority.Lowest;
            preJitThread.Start();
        }


        public static void PreJit(Assembly assembly)
        {
            var classes = assembly.GetTypes();
            foreach (var classType in classes)
            {
                PreJitMarkedMethods(classType);
            }
        }


        public static void BeginPreJit(Assembly assembly)
        {
            Thread preJitThread = new Thread(() =>
            {
                PreJit(assembly);
            });

            preJitThread.Name = "PreJittingThread";
            preJitThread.Priority = ThreadPriority.Lowest;
            preJitThread.Start();
        }

        public static void BeginPreJit(object instance)
        {
            Thread preJitThread = new Thread(() =>
            {
                PreJit(instance);
            });

            preJitThread.Name = "PreJittingThread";
            preJitThread.Priority = ThreadPriority.Lowest;
            preJitThread.Start();
        }

        private static void PreJitMarkedMethods(Type type)
        {
            // get the type of all the methods within this instance
            var methods = type.GetMethods(BindingFlags.DeclaredOnly |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Public |
                                        BindingFlags.Instance |
                                        BindingFlags.Static);
           
            // for each time, jit methods marked with prejit attribute
           // Jit all methods
            if (methods.Length > 30)
            {
                int NumThreads = 2; 
                int len = methods.Length / NumThreads;

                var workers = new Worker[NumThreads];
                for (int i = 0; i < NumThreads; i++)
                    workers[i] = new Worker(i * len, i * len + len, methods );

                foreach (var w in workers)
                    w.Thread.Join();

                int[] accumulator = new int[256];
                for (int i = 0; i < workers.Length; i++)
                    for (int j = 0; j < accumulator.Length; j++)
                        accumulator[j] += workers[i].Accumulator[j];
            }else
            {
                for (int i = 0; i < methods.Length; i++)
                    // jitting of the method happends here.
                    RuntimeHelpers.PrepareMethod(methods[i].MethodHandle);
            }
                //if (ContainsPreJitAttribute(method))
                //{
                //    // jitting of the method happends here.
                    
                //}
            
        }


        private static void PreJitAllMethods(Type type)
        {
            var sw = new Stopwatch();
            sw.Start();
            // get the type of all the methods within this instance
            var methods = type.GetMethods(BindingFlags.DeclaredOnly |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Public |
                                        BindingFlags.Instance |
                                        BindingFlags.Static);

            // Jit all methods
            if (methods.Length > 30)
            {
                int NumThreads = 2; 
                int len = methods.Length / NumThreads;

                var workers = new Worker[NumThreads];
                for (int i = 0; i < NumThreads; i++)
                    workers[i] = new Worker(i * len, i * len + len, methods );

                foreach (var w in workers)
                    w.Thread.Join();

                int[] accumulator = new int[256];
                for (int i = 0; i < workers.Length; i++)
                    for (int j = 0; j < accumulator.Length; j++)
                        accumulator[j] += workers[i].Accumulator[j];
            }else
            {
                for (int i = 0; i < methods.Length; i++)
                    // jitting of the method happends here.
                    RuntimeHelpers.PrepareMethod(methods[i].MethodHandle);
            }
                Debug.WriteLine("Time to Pre JIT " + sw.Elapsed);
            
        }


        private static bool ContainsPreJitAttribute(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes(typeof(PreJitAttribute), false);
            if (attributes != null)
                if (attributes.Length > 0)
                {
                    return true;
                }

            return false;
        }
    }
}
