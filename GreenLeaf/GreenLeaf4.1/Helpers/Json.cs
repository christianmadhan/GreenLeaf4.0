using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Models;
using Newtonsoft.Json;

namespace GreenLeaf4._1.Helpers
{

    /*
        When we retrived Data from the web its in XML. We want that
        To be converted to JSON format. Because we are using that converter a lot
        It makes more sense to have a specific file which we then call and then use
        the method inside that file.
     */
   public static class Json
    {
        public static async Task<T> ToObjectAsync<T>(string value)
        {
            return await Task.Run<T>(() =>
            {
                return JsonConvert.DeserializeObject<T>(value);
            });
        }

        public static async Task<string> StringifyAsync(object value)
        {
            return await Task.Run<string>(() =>
            {
                return JsonConvert.SerializeObject(value);
            });
        }

        public static ObservableCollection<CTask> TransformData(string data)
        {
           return JsonConvert.DeserializeObject<ObservableCollection<CTask>>(data);
        }
    }
}
