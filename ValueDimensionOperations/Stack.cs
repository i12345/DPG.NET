using DotNetHelpers.Extensions;

namespace DPG.NET.ValueDimensionOperations;

/// <summary>
/// Stacks a virtual ValueDimension into (an array?)
/// </summary>
/// <param name="Dimension">the dimensions to copy from input to output when matched</param>
public record Stack(ValueDimension Dimension)
    : IValueDimensionOperation
{
    public void Compile(
            IList<ValueDimension.Compiled> inputs,
            IList<ValueDimension.Compiled> outputs,
            ValueDimension.CompilerContext context
        )
    {
        var dimension = context[Dimension];

        if(!dimension.IsVirtual)
            throw new InvalidDataException($"Cannot stack over non-virtual dimension \"${Dimension}\"");

        if (!dimension.CutFrom(inputs, context))
            throw new Exception("TODO: log error gracefully");

        outputs.Add(dimension with { IsVirtual = false });
    }
}