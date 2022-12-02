
using static Challenge.Converter;

namespace Challenge
{
    public static class Extensions
    {
        public static List<T2> MapCollection<T1,T2>(this List<T1> inputlist, MyDelegateConverter<T1,T2> converter)
        {
            var person =  converter(inputlist);
            return person;
        }

    }
}
