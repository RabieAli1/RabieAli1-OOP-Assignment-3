namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1.  (IsValidEgyptianPhone)
            Console.WriteLine("01012345678".IsValidEgyptianPhone());     
            Console.WriteLine("+201512345678".IsValidEgyptianPhone());     
            Console.WriteLine("01312345678".IsValidEgyptianPhone());       
            Console.WriteLine("0101234567".IsValidEgyptianPhone());      
            Console.WriteLine("0101234567a".IsValidEgyptianPhone());       

            // 2. (IsValidEgyptianNationalId)
            Console.WriteLine("29901011234567".IsValidEgyptianNationalId()); 
            Console.WriteLine("19901011234567".IsValidEgyptianNationalId()); 
            Console.WriteLine("2990101123456".IsValidEgyptianNationalId());  
        }
    }
}
