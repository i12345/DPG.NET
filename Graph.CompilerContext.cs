using DotNetHelpers;

namespace DPG.NET;

public partial record Graph {
    public class CompilerContext
        : ICompilerContext<Graph, Graph.Compiled, Graph.CompilerContext>
    {
        public Graph Graph { get; init; }

        public DimensionDefinition.CompilerContext DimensionDefinitions { get; init; }
        public ValueDimension.CompilerContext ValueDimensions { get; init; }
        public Node.CompilerContext Nodes { get; init; }
        public ValueType.CompilerContext ValueTypes { get; init; }
        public ValueSpec.CompilerContext ValueSpecs { get; init; }

        public Graph.Compiled this[Graph graph] =>
            throw new InvalidOperationException();

        public CompilerContext(Graph graph)
        {
            Graph = graph;

            DimensionDefinitions = new(this);
            ValueDimensions = new(this);
            Nodes = new(this);
            ValueTypes = new(this);
            ValueSpecs = new(this);
        }
    }
}