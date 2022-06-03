using DotNetHelpers;
using DotNetHelpers.Extensions;

namespace DPG.NET.NodeFunctions;
public record class DimensionChanger(
        IValueDimensionOperation[] DimensionOperations
    )
    : INodeFunction {
    public INodeFunction.Compiled Compile(
            Node node,
            INamed<Node.Compiled.ValueRef>[] inputs,
            ValueDimension.Compiled[] inputDimensions,
            Graph.CompilerContext context
        ) {
        var inputDimensions_list = new List<ValueDimension.Compiled>(inputDimensions);
        var outputDimensions_list = new List<ValueDimension.Compiled>();

        DimensionOperations.Iterate(
                dimensionOperation =>
                    dimensionOperation.Compile(
                            inputDimensions_list,
                            outputDimensions_list,
                            context.ValueDimensions
                        )
            );

        var outputDimensions = outputDimensions_list.ToArray();
        // var dimensions_changed_removed = inputDimensions.Where(dimension => !outputDimensions.Contains(dimension));
        // var dimensions_changed_added = outputDimensions.Where(dimension => !inputDimensions.Contains(dimension));

        // TODO: What if a subdimension was operated on?

        var outputs =
            (
                from input in inputs
                let type_new =
                    input.Value.ValueSpec.Type
                    with { AssociatedDimensions = outputDimensions }
                let valueSpec_new = 
                    input.Value.ValueSpec
                    with { Type = type_new }
                select new Node.Compiled.ValueRef(
                        node.ID,
                        input.Name,
                        valueSpec_new
                    )
            ).ToArray();

        return new Compiled(
                inputs,
                outputs
            );
    }

    public record class Compiled(
            INamed<Node.Compiled.ValueRef>[] Inputs,
            Node.Compiled.ValueRef[] Outputs
        )
        : INodeFunction.Compiled
    {
    }
}