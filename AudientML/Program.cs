using AudientMLML.Model;
using Microsoft.ML;
using System;
using System.Reflection;

namespace AudientML
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelInput data = new ModelInput();
            var features = "rock,-1.13947,0.17516886,-1.5538154,0.41143337,-0.57987577,0.3658361,-0.8737631,0.31099418,-0.6114717,0.22522274,-0.36270136,0.21625315,-0.19452207,0.19064106,-0.058592424,0.03778343,-0.21190715,0.09087317,-0.16246094,0.050544135,-0.08509372,0.008931654,-0.12052887,0.08522095,0.01979195,0.12628011,0.08306938,0.90629965,1544.9125,1601.7399,0.3005298,0.17325823,3328.125,129.86523,0.033054575,0.8297714";
            var feature_list = features.Split(",");

            FieldInfo[] fi = typeof(ModelInput).GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            int ind = 0;
            foreach (FieldInfo info in fi)
            {
                if (ind == 0)
                {
                    info.SetValue(data, feature_list[ind]);
                }
                else
                {
                    info.SetValue(data, float.Parse(feature_list[ind]));
                }
                ind += 1;
            }
            ModelOutput prediction = ConsumeModel.Predict(data);
            Console.WriteLine($"Prediction: {prediction.Prediction}");
        }
    }
}
