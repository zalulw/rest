using CommunityToolkit.Mvvm.ComponentModel;

namespace Solution.Core.Models;

public partial class MotorcycleModel : ObservableObject
{
    [ObservableProperty]
    private string id;

    [ObservableProperty]
    private string imageId;

    [ObservableProperty]
    private string webContentLink;

    [ObservableProperty]
    private ManufacturerModel manufacturer;

    [ObservableProperty]
    private TypeModel type;

    [ObservableProperty]
    private string model;

    [ObservableProperty]
    private int cubic;

    [ObservableProperty]
    private int releaseYear;

    [ObservableProperty]
    private int numberOfCylinders;

    public MotorcycleModel()
    {
        
    }

    public MotorcycleModel(MotorcycleEntity entity)
    {
        this.Id = entity.PublicId;
        this.ImageId = entity.ImageId;
        this.WebContentLink = entity.WebContentLink;
        this.Manufacturer.Value = new ManufacturerModel(entity.Manufacturer);
        this.Type.Value = new TypeModel(entity.Type);
        this.Model.Value = entity.Model;
        this.Cubic.Value = entity.Cubic;
        this.ReleaseYear.Value = entity.ReleaseYear;
        this.NumberOfCylinders.Value = entity.Cylinders;
    }

    public MotorcycleEntity ToEntity()
    {
        return new MotorcycleEntity
        {
            PublicId = Id,
            ManufacturerId = Manufacturer.Id,
            TypeId = Type.Id,
            ImageId = ImageId,
            WebContentLink = WebContentLink,
            Model = Model.Value,
            Cubic = Cubic.Value,
            ReleaseYear = ReleaseYear,
            Cylinders = NumberOfCylinders
        };
    }

    public void ToEntity(MotorcycleEntity entity)
    {
        entity.PublicId = Id;
        entity.ManufacturerId = Manufacturer.Id;
        entity.TypeId = Type.Value.Id;
        entity.ImageId = ImageId;
        entity.WebContentLink = WebContentLink;
        entity.Model = Model;
        entity.Cubic = Cubic;
        entity.ReleaseYear = ReleaseYear;
        entity.Cylinders = NumberOfCylinders;
    }

}
