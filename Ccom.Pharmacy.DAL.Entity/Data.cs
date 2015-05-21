using System.ComponentModel;

namespace Ccom.Pharmacy.DAL.Entity
{
    
    public class Person : IDataErrorInfo
    {
        private int age;
        
        public int Age
        {
            get { return age; }
            set 
            {
                age = value;
                
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "Age")
                {
                    if (age < 0)
                    {
                        result = "Age should be Greter than 0.";
                        //Window1 w1 = new Window1();
                        //w1.l1.Content = result;                       
                    }
                }
                return result;
            }
        }
    }
}