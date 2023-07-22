using System;
using System.Runtime.Serialization;

namespace AvaloniaDi.Exceptions;

public class SiteveyorAvaloniaException : Exception
{
	/// <inheritdoc />
	public SiteveyorAvaloniaException()
	{
	}

	/// <inheritdoc />
	protected SiteveyorAvaloniaException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}

	/// <inheritdoc />
	public SiteveyorAvaloniaException(string? message) : base(message)
	{
	}

	/// <inheritdoc />
	public SiteveyorAvaloniaException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}