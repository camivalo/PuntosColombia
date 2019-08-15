using System;
using System.Collections.Generic;
using System.Text;

namespace PuntosColombia.Bussiness
{
    public interface IMissingNumbers
    {
        string SearchMissingNumbers(int n, int m, List<int> arr, List<int> brr);
    }
}
