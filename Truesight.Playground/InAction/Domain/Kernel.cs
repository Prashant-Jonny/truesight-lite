﻿using System;
using XenoGears.Reflection.Shortcuts;
using XenoGears.Assertions;

namespace Truesight.Playground.InAction.Domain
{
    internal abstract class Kernel<T1, T2, T3> : IKernel<T1, T2, T3>
    {
        public virtual dim3 GridDim { get { throw new NotSupportedException(); } }
        public virtual int3 BlockIdx { get { throw new NotSupportedException(); } }
        public virtual dim3 BlockDim { get { throw new NotSupportedException(); } }
        public virtual int3 ThreadIdx { get { throw new NotSupportedException(); } }
        public virtual void SyncThreads(params Object[] keys) { throw new NotSupportedException(); }

        protected abstract void RunKernel(T1 arg1, T2 arg2, T3 arg3);
        void IKernel<T1, T2, T3>.RunKernel(T1 arg1, T2 arg2, T3 arg3)
        {
            // note. works around a stupid Reflection.Emit bug with multidimensional arrays
            // type signatures for overriding method parameters get emitted as T[,]
            // whereas the base signature generated by csc has parameters of type T[0..,0..]
            // unfortunately, there's nothing we can do here

            var overrider = GetType().GetMethod("RunKernel", BF.All | BF.DeclOnly);
            overrider.AssertNotNull().Invoke(this, new Object[]{arg1, arg2, arg3});
        }
    }
}