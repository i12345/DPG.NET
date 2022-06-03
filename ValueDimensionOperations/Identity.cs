using DotNetHelpers.Extensions;

namespace DPG.NET.ValueDimensionOperations;

/// <summary>
/// The identity IValueDimensionOperation just copies input value dimensions
/// to the output value dimensions, optionally filtered by a predefined array
/// of ValueDimensionDefinition's.
/// </summary>
/// <param name="RestDimensions">the dimensions to copy from input to output when matched</param>
public record Identity(ValueDimension[]? FilterDimensions)
    : IValueDimensionOperation
{
    public void Compile(
            IList<ValueDimension.Compiled> inputs,
            IList<ValueDimension.Compiled> outputs,
            ValueDimension.CompilerContext context
        ) {
        var matched =
            FilterDimensions != null ?
                FilterDimensions
                    .Select(dimension => context[dimension])
                    .SideAction(
                            dimension =>
                                dimension
                                    .CutFrom(inputs, context)
                                    .AssertTrue(new Exception("todo: error gracefully"))
                        ) :
                inputs.SideAction(inputs.Remove);

        matched.Iterate(outputs.Add);
    }
}