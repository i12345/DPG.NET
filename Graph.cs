namespace DPG.NET;

public partial record Graph(
        string Name,
        Node[] Nodes
    )
    : ICompilable<Graph, Graph.Compiled, Graph.CompilerContext> {
    public Node this[NodeID nodeID] =>
        Nodes.Single(node => node.ID == nodeID);

    public Compiled Compile(CompilerContext context) =>
        new Compiled(
                Name,
                Nodes
                    .Select(node => context.Nodes[node])
                    .ToArray()
            );

    public record Compiled(
            string Name,
            Node.Compiled[] Nodes
        );
}