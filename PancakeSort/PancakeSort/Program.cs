using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSort
{
    class Program
    {
        static void Main(string[] args) => Process();

        static void Process(){
            Console.Write("Enter array elements: ");
            var tempArray = Console.ReadLine().Split(new[] { ' ', ',', ';' }, 
                StringSplitOptions.RemoveEmptyEntries);
            var array = new int[tempArray.Length];
            try {
                for (int i = 0; i < tempArray.Length; i++) 
                    array[i] = Convert.ToInt32(tempArray[i]);
                Console.WriteLine($"Sorted array: {String.Join(", ", PancakeSort(array))}");
                Repeat();
                return;
            }
            catch {
                Console.Clear();
                Console.WriteLine("Try again...");
                Process();
                return;
            }
        }
        static void Repeat() {
            Console.Write("Want to sort another array? (yes/no) - ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer == "yes"){
                answer = "";
                Console.Clear();
                Process();
                return;
            }
            else if (answer == "no") {
                Console.WriteLine("Shutting down...");
                return;
            }
            else{
                Console.Clear();
                Console.WriteLine("Try again...");
                answer = "";
                Repeat();
                return;
            }
        }

        static int[] PancakeSort(int[] array){
            for (var aLength = array.Length - 1; aLength >= 0; aLength--) {
                var indexOfMax = IndexOfMax(array, aLength);
                if (indexOfMax != aLength) {
                    Flip(array, indexOfMax);
                    Flip(array, aLength);
                }
            }

            return array;
        }

        static void Flip(int[] array, int end){
            for (var start = 0; start < end; start++, end--){
                var temp = array[start];
                array[start] = array[end];
                array[end] = temp;
            }
        }

        static int IndexOfMax(int[] array, int n){
            var result = 0;
            for (var i = 0; i <= n; ++i) {
                if (array[i] > array[result])
                    result = i;
            }

            return result;
        }
    }
}
