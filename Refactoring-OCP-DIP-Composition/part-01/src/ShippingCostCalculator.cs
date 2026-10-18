namespace RefactoringLab;


// المشكلة اللي قبلتها هنا قب الريفاكتورينج هو اني لو عايز اضيف حالة جديدة هضطر اعدل على الكود في الاف كوندشن و ده بيخالف مبدئ 
// OCP 
// solution => i will use interface then impelemet from it if i want add other case or ShippingCarrier
public class ShippingCostCalculator
{

    public decimal Calculate(IShippingCarrier carrier, decimal weightKg) 
    {
        if (carrier == null)
            throw new ArgumentNullException(nameof(carrier));
        return carrier.CalculateCost(weightKg);
    }


}


public interface IShippingCarrier
{
    decimal CalculateCost(decimal weightKg);
}


public class AramexCarrier : IShippingCarrier
{
    public decimal CalculateCost(decimal weightKg) => weightKg * 12m;

}

public class FedExCarrier : IShippingCarrier
{
    public decimal CalculateCost(decimal weightKg) => weightKg * 15m;

}

public class DHLCarrier : IShippingCarrier
{
    public decimal CalculateCost(decimal weightKg) => weightKg * 18m;

}

public class BostaCarrier : IShippingCarrier
{
    public decimal CalculateCost(decimal weightKg) => weightKg * 10m;
}

// قبل الريفاكتورينج
// public decimal Calculate(string carrier, decimal weightKg)
// {
//     switch (carrier)
//     {
//         case "Aramex":
//             return weightKg * 12m;
//         case "FedEx":
//             return weightKg * 15m;
//         case "DHL":
//             return weightKg * 18m;
//         default:
//             throw new ArgumentException($"Unknown carrier: {carrier}");
//     }
// }
