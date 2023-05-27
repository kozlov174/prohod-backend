﻿using Prohod.Domain.ErrorsBase;

namespace Prohod.Domain.RepositoriesBase;

public record EntityNotFound<TEntity> : IOperationError
{
    public T Accept<T>(IOperationErrorVisitor<T> visitor) => visitor.Visit(this);
}