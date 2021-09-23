using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentityService.Shared.Extensions {
  public static class SerializationExtension {

    public static string ToJson<T>(this T @object) {
      return @object is null ? null : JsonConvert.SerializeObject(@object);
    }

    public static T FromJson<T>(this string json) {
      return string.IsNullOrEmpty(json)
          ? default
          : JsonConvert.DeserializeObject<T>(json);
    }

    public static byte[] ToByteArray(this object @object) {
      if (@object is null) {
        return default;
      }

      using var ms = new MemoryStream();
      using var writer = new BsonDataWriter(ms);
      var serializer = new JsonSerializer();
      serializer.Serialize(writer, @object);

      return ms.ToArray();
    }

    public static T FromByteArray<T>(this byte[] byteArray)
        where T : class {
      if (byteArray is null) {
        return default;
      }

      using var ms = new MemoryStream();
      using var reader = new BsonDataReader(ms);
      var serializer = new JsonSerializer();
      var result = serializer.Deserialize<T>(reader);

      return result;
    }
  }
}
