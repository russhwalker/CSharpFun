namespace CSharpFun.Base
{
    public interface IVehicle
    {
        int VehicleId { get; set; }
        void MakeNoise();
        //OtherTypes.VehicleType VehicleType { get; set; }
    }
}