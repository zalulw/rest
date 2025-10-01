﻿namespace Solution.Core.Models;

public partial class TypeModel : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name;

    public TypeModel()
    {
    }

    public TypeModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public TypeModel(MotorcycleTypeEntity entity)
    {
        if (entity is null)
        {
            return;
        }

        Id = entity.Id;
        Name = entity.Name;
    }

    public MotorcycleTypeEntity ToEntity()
    {
        return new MotorcycleTypeEntity
        {
            Name = Name,
            Id = Id
        };
    }

    public void ToEntity(MotorcycleTypeEntity entity)
    {
        entity.Name = Name;
        entity.Id = Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is TypeModel model &&
               Id == model.Id &&
               Name == model.Name;  
    }
}
