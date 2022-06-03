using DotNetHelpers;
using DotNetHelpers.Extensions;

namespace DPG.NET;
public partial record Node(
        NodeID ID,
        INodeFunction Function,
        INamed<Node.ValueRef>[] Inputs,
        Node.ValueRef[] Outputs
    )
    : ICompilable<
            Node,
            Node.Compiled,
            Node.CompilerContext
        > {
    public ValueRef this[string outputName] =>
        Outputs.Single(output => output.OutputName == outputName);
    
    public Compiled Compile(CompilerContext context) {
        var inputs_compiled =
            Inputs
                .Select(
                        input =>
                            context
                                [input.Value.NodeID]
                                [input.Value.OutputName]
                                .Named(input.Name)
                    )
                .ToArray();

        var inputDimensions =
            context
                .CombineDimensions(
                        inputs_compiled
                            .Select(input => input.Value)
                            .ToArray()
                    );

        var function_compiled =
            Function.Compile(
                    this,
                    inputs_compiled,
                    inputDimensions,
                    context.Parent
                );

        return new Node.Compiled(
                ID,
                function_compiled,
                inputs_compiled,
                function_compiled.Outputs
            );
    }

    public record class Compiled(
                NodeID ID,
                INodeFunction.Compiled Function,
                INamed<Compiled.ValueRef>[] Inputs,
                Compiled.ValueRef[] Outputs
            ) {
        public Compiled.ValueRef this[string outputName] =>
            Outputs.Single(output => output.OutputName == outputName);

        public record ValueRef(
                NodeID NodeID,
                string OutputName,
                ValueSpec.Compiled ValueSpec
            );
    }

    public record ValueRef(
            NodeID NodeID,
            string OutputName
        );
}