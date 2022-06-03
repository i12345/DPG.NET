namespace DPG.NET;
partial record ValueSpec {
    public class CompilerContext
        : MemoizingChildCompilerContext<
                ValueSpec, ValueSpec.Compiled, ValueSpec.CompilerContext,
                Graph, Graph.Compiled, Graph.CompilerContext
            > {
        public CompilerContext(Graph.CompilerContext parent)
            : base(parent) { }
    }
}