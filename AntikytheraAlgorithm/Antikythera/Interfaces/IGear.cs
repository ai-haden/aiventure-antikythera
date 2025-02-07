
namespace Antikythera.Interfaces
{
    public interface IGear
    {
        double GetCircumference();
        double StoreCheck(double check);
        double? StoreInputScalar(double value);
        double? StoreOutputScalar(double value);
    }
}
