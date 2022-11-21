using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DesignPatterns
{
    public interface IMobile 
    {
        IAndroid GetAndroidPhone();
        IiOS GetiOSPhone();
    }

    public interface IAndroid
    {
        string GetModelDetails();
    }

    public interface IiOS
    {
        string GetModelDetails();
    }

    public class Samsung : IMobile
    {
        public IAndroid GetAndroidPhone()
        {
            return new SamsungGalaxy();
        }

        public IiOS GetiOSPhone()
        {
            return new SamsungGuru();
        }
    }

    public class SamsungGalaxy : IAndroid
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Galaxy";
        }
    }

    public class SamsungGuru : IiOS
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Guru";
        }
    }

    public class MobileClient
    {
        IAndroid androidPhone;
        IiOS iOSPhone;

        public MobileClient(IMobile factory)
        {
            this.androidPhone = factory.GetAndroidPhone();
            this.iOSPhone = factory.GetiOSPhone();
        }

        public string GetAndroidPhoneDetails()
        {
            return androidPhone.GetModelDetails();
        }

        public string GetiOSPhoneDetails()
        {
            return iOSPhone.GetModelDetails();
        }
    }

    public class AbstractFactory 
    { 
        public static void PhoneFactoryTest()
        {
            IMobile samsungMobilePhone = new Samsung();
            MobileClient samsungClient = new MobileClient(samsungMobilePhone);

            Debug.WriteLine(samsungClient.GetAndroidPhoneDetails());
            Debug.WriteLine(samsungClient.GetiOSPhoneDetails());
        }
    }
}
