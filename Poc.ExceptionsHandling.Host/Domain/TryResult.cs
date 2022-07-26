using System.Diagnostics.CodeAnalysis;
using Trainline.NetStandard.Exceptions.Contracts;

namespace Poc.ExceptionsHandling.Host.Domain;

public struct TryResult
{
    public TryResult()
    {
        IsSuccess = true;
        Error = null;
    }

    private TryResult(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public static TryResult Success()
    {
        return new TryResult();
    }

    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess { get; }

    public Error? Error { get; }

    public static implicit operator TryResult(Error error) => new(error);
}

public struct TryResult<TResult>
{
    private TryResult(TResult item)
    {
        IsSuccess = true;
        Item = item;
        Error = null;
    }
    private TryResult(Error error)
    {
        IsSuccess = false;
        Item = default;
        Error = error;
    }

    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess { get; }

    public Error? Error { get; }

    public TResult? Item { get; }

    public static implicit operator TryResult<TResult>(TResult value) => new(value);

    public static implicit operator TryResult<TResult>(Error error) => new(error);
}
