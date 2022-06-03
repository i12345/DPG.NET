namespace DPG.NET;

partial record Node {
    public class CompilerContext
        : MemoizingChildCompilerContext<
                Node, Node.Compiled, Node.CompilerContext,
                Graph, Graph.Compiled, Graph.CompilerContext
            > {
        public Node.Compiled this[NodeID nodeID] =>
            this[Parent.Graph[nodeID]];

        public CompilerContext(Graph.CompilerContext parent)
            : base(parent) { }

        public ValueDimension.Compiled[] CombineDimensions(Node.Compiled.ValueRef[] outputs) =>
            Parent
                .ValueDimensions
                .CombineDimensionSets(
                        outputs
                            .Select(output => output.ValueSpec.Dimensions)
                            .ToArray()
                    );
    }
}