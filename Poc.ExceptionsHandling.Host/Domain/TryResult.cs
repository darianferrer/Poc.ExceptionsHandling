using System.Diagnostics.CodeAnalysis;
using Trainline.NetStandard.Exceptions.Contracts;

namespace Poc.ExceptionsHandling.Host.Domain;

public class TryResult
{
    protected TryResult()
    {
        IsSuccess = true;
    }

    protected TryResult(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public static TryResult Success()
    {
        return new TryResult();
    }

    [MemberNotNullWhen(false, nameof(Error))]
    public virtual bool IsSuccess { get; }

    public Error? Error { get; }

    public static implicit operator TryResult(Error error) => new(error);
}

public class TryResult<TResult> : TryResult
{
    protected TryResult(TResult item) : base()
    {
        Item = item;
    }
    protected TryResult(Error error) : base(error)
    {
    }

    public TResult? Item { get; }

    public static implicit operator TryResult<TResult>(TResult value) => new(value);

    public static implicit operator TryResult<TResult>(Error error) => new(error);
}
