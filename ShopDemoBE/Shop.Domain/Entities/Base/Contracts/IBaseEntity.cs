﻿namespace Shop.Domain.Entities.Base.Contracts;

public interface IBaseEntity<T> { T Id { get; set; } }