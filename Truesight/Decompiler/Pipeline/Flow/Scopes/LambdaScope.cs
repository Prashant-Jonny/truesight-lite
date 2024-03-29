using System;
using System.Collections.ObjectModel;
using Truesight.Decompiler.Hir;
using Truesight.Decompiler.Hir.Core.ControlFlow;
using Truesight.Decompiler.Pipeline.Flow.Cfg;
using XenoGears.Functional;
using XenoGears.Assertions;
using XenoGears.Strings;

namespace Truesight.Decompiler.Pipeline.Flow.Scopes
{
    internal class LambdaScope : IScope<Block>
    {
        public IScope Parent { get { return null; } }

        private readonly Block _block;
        Node IScope.Hir { get { return Hir; } }
        public Block Hir { get { return _block; } }

        private readonly ControlFlowGraph _cfg;
        public BaseControlFlowGraph LocalCfg { get { return _cfg; } }
        public ReadOnlyCollection<Offspring> Offsprings { get { return Seq.Empty<Offspring>().ToReadOnly(); } }

        public ControlFlowBlock Return { get { return _cfg.Finish; } }
        public ReadOnlyCollection<ControlFlowBlock> Pivots { get { return _cfg.Finish.MkArray().ToReadOnly(); } }

        public static LambdaScope Decompile(ControlFlowGraph cfg) { return new LambdaScope(cfg); }
        private LambdaScope(ControlFlowGraph cfg)
        {
            _cfg = cfg;
            _block = ComplexScope.Decompile(this, cfg).Hir;
        }

        public String Uri
        {
            get
            {
                Parent.AssertNull();
                return Syms.Lambda;
            }
        }

        public override String ToString()
        {
            var lite = Uri.Replace("complex :: ", "");
            lite = lite.Replace("body :: ", "");
            return "{" + lite + "}";
        }
    }
}