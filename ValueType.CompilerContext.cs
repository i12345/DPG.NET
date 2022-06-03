namespace DPG.NET;
partial record ValueType {
    public class CompilerContext
        : MemoizingChildCompilerContext<
                ValueType, ValueType.Compiled, ValueType.CompilerContext,
                Graph, Graph.Compiled, Graph.CompilerContext
            > {
        public CompilerContext(Graph.CompilerContext parent)
            : base(parent) { }
    }
}