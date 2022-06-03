using DotNetHelpers.Extensions;

namespace DPG.NET.ValueDimensionOperations;

/// <summary>
/// Make virtual a non-virtual ValueDimension
/// </summary>
/// <param name="RestDimensions">the dimensions to copy from input to output when matched</param>
public record For(ValueDimension Dimension)
    : IValueDimensionOperation
{
    public void Compile(
            IList<ValueDimension.Compiled> inputs,
            IList<ValueDimension.Compiled> outputs,
            ValueDimension.CompilerContext context
        )
    {
        var dimension = context[Dimension];

        if(dimension.IsVirtual)
            throw new InvalidDataException($"Cannot iterate over virtual dimension \"${Dimension}\"");

        if (!dimension.CutFrom(inputs, context))
            throw new Exception("TODO: log error gracefully");

        outputs.Add(dimension with { IsVirtual = true });
    }
}