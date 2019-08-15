using System;
using System.Collections.Generic;
using System.Linq;

namespace PuntosColombia.Bussiness
{
    public class MissingNumbers : IMissingNumbers
    {

        public MissingNumbers()
        {

        }

        public string SearchMissingNumbers(int n, int m, List<int> arr, List<int> brr)
        {
            var response = string.Empty;

            if (n <= 0 || n >= (2 * Math.Pow(10, 5)))
            {
                response = "Error_n Quantity List A is out of range";
                return response;
            }

            if (m <= 0 || m >= (2 * Math.Pow(10, 5)))
            {
                response = "Error_m Quantity List B is out of range";
                return response;
            }

            if (n > m)
            {
                response = "Error_n>m Quantity List A  is greater than Quantity List B";
                return response;
            }

            if ((brr.Any(x => x <= 0 || x > (Math.Pow(10, 4)))))
            {
                response = "Error_brr some List B items are greater than " + Math.Pow(10, 4);
                return response;
            }

            if ((brr.Max() - brr.Min()) > 100)
            {
                response = "Error_Max_Min the maximum value of list B minus the minimum value is greater than 100";
                return response;
            }

            response = CompareList(arr, brr);


            return response;
        }

        private string CompareList(List<int> arr, List<int> brr)
        {
            arr.Sort();
            brr.Sort();

            List<int> diferentNumberList = new List<int>();

            foreach (var itemListB in brr.Distinct())
            {

                var countA = arr.Count(x => x == itemListB);
                var countB = brr.Count(x => x == itemListB);

                if (countA != countB)
                    diferentNumberList.Add(itemListB);

            }

            var missingNumbersFound = string.Join(" ", diferentNumberList);

            return missingNumbersFound;
        }
    }
}
