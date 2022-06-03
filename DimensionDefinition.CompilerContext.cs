namespace DPG.NET;
partial record DimensionDefinition {
    public class CompilerContext
        : MemoizingChildCompilerContext<
                DimensionDefinition, DimensionDefinition.Compiled, DimensionDefinition.CompilerContext,
                Graph, Graph.Compiled, Graph.CompilerContext
            >
    {
        public override Compiled this[DimensionDefinition start] => base[start];

        public CompilerContext(Graph.CompilerContext parent)
            : base(parent) {
            
        }
    }
}