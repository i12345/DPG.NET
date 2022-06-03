using DotNetHelpers;

namespace DPG.NET;
public interface INodeFunction {
    Compiled Compile(
            Node node,
            INamed<Node.Compiled.ValueRef>[] inputs,
            ValueDimension.Compiled[] inputDimensions,
            Graph.CompilerContext context
        );

    public interface Compiled {
        INamed<Node.Compiled.ValueRef>[] Inputs { get; }
        Node.Compiled.ValueRef[] Outputs { get; }
    }
}