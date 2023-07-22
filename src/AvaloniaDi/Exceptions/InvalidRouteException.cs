using System;
using System.Runtime.Serialization;

namespace AvaloniaDi.Exceptions;

public class InvalidRouteException : SiteveyorAvaloniaException
{
	/// <inheritdoc />
	public InvalidRouteException() : base("The requested route does not exist.")
	{
	}

	/// <inheritdoc />
	protected InvalidRouteException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}

	/// <inheritdoc />
	public InvalidRouteException(string? message) : base(message)
	{
	}

	/// <inheritdoc />
	public InvalidRouteException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}