namespace Assigment.Net.OOP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q 1

            #region a
            //a)  What is the difference between Method Overloading and Method Overriding?
            //The purpose of method overloading is to reuse the function in more than one way,
            //while method overriding is to change the base function in more than one place.
            #endregion

            #region b
            //b)  What is the difference between Static Binding and Dynamic Binding?
            //Static Binding => Early Binding is called during code reading.
            //Dynamic Binding => Late لآinding is called in run time.
            #endregion

            #endregion

            #region Q 2

            #region a
            //a)  What is the purpose of the sealed keyword when applied to a class?
            //To prevent inheritance by any other class after that.
            #endregion

            #region b
            //b)  What is the difference between a sealed class and a sealed method?
            //A sealed class cannot be inherited by any other class.
            //A sealed method is a method that cannot be overridden in any derived class, but the class itself can still be inherited.
            #endregion

            #region c
            //c)  Can a sealed method be overridden? Why?
            //Yes, this keyword prevents inheritance for any method after that, not just the method it is on.
            #endregion

            #endregion
        }
    }
}
